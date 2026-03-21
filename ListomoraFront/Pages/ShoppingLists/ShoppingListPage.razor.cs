using ListomoraFront.Models;
using ListomoraFront.Models.Enums;
using ListomoraFront.Models.ShoppingLists;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ListomoraFront.Pages.ShoppingLists
{
    public partial class ShoppingListPage
    {
        [Inject]
        private IShoppingListService _client { get; set; }
        [Inject]
        private IArticleService _articleClient { get; set; }
        [Inject]
        private ISnackbar _snackbar { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        [Parameter]
        public Guid? Id { get; set; }
        [Parameter]
        public string SourceUrl { get; set; }

        private ShoppingListDetailsDto shoppingList { get; set; } = new();

        private List<ShoppingListLineVM> _lines = new();
        private List<ShoppingListLineCreateUpdateVM> _linesUpdate = new();
        private bool _hasChanges = false;

        protected override async Task OnInitializedAsync()
        {
            switch (SourceUrl)
            {
                case "adminlist":
                case "mine":
                    break;
                default:
                    SourceUrl = "mine";
                    await InvokeAsync(StateHasChanged);
                    break;
            }
            if (Id is not null)
                await LoadData();
        }

        private async Task LoadData()
        {
            shoppingList = await _client.GetByIdAsync((Guid)Id);
            _lines = shoppingList.ShoppingListLines?.Select(x => new ShoppingListLineVM()
            {
                Data = x,
            }).ToList() ?? new();
            foreach (var line in _lines)
            {
                if (line.Data.ArticleId != null)
                {
                    line.Data.OriginArticleId = line.Data.ArticleId;
                    line.Data.SelectedArticle = new ShoppingListLineArticleDto
                    {
                        Id = line.Data.ArticleId,
                        Name = line.Data.ArticleName
                    };
                }
            }
            _linesUpdate = new();
        }

        private async Task<IEnumerable<ShoppingListLineArticleDto>> SearchArticles(string value, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 1)
                return Enumerable.Empty<ShoppingListLineArticleDto>();

            // appel API
            return await _articleClient.Search(value);
        }

        private void OnArticleSelected(ShoppingListLineVM line, ShoppingListLineArticleDto? article)
        {
            if (article == null)
                return;

            line.Data.ArticleId = article.Id;
            line.Data.ArticleName = article.Name;
            line.Data.SelectedArticle = article;

            ModifyLine(line);
            _hasChanges = true;
        }

        private void OnLineChanged(ShoppingListLineVM line, object? value, string field)
        {
            switch (field)
            {
                case nameof(line.Data.Amount):
                    line.Data.Amount = (double?)value;
                    break;

                case nameof(line.Data.Unit):
                    line.Data.Unit = (UnitTypeEnum?)value;
                    break;

                case nameof(line.Data.Price):
                    line.Data.Price = (decimal?)value;
                    break;
            }

            ModifyLine(line);
            _hasChanges = true;
        }

        private void AddLine()
        {
            ShoppingListLineVM line = new();
            _lines.Add(line);
            _linesUpdate.Add(new ShoppingListLineCreateUpdateVM(line.LocalId));
        }

        private void ModifyLine(ShoppingListLineVM line)
        {
            var newLineDto = new ShoppingListLineCreateUpdateDto()
            {
                OriginArticleId = line.Data.OriginArticleId,
                ArticleId = line.Data.ArticleId,
                ShoppingListId = shoppingList.Id,
                Amount = line.Data.Amount,
                Unit = line.Data.Unit,
                Price = line.Data.Price,
            };

            var listLine = _linesUpdate.SingleOrDefault(x => x.LocalId == line.LocalId);

            if (listLine is null)
            {
                newLineDto.IsNew = false;
                newLineDto.IsModified = true;
                _linesUpdate.Add(new ShoppingListLineCreateUpdateVM(line.LocalId)
                {
                    Data = newLineDto,
                });
            }
            else
            {
                if (listLine.Data.IsDeleted)
                    _snackbar.Add("Vous essayez de modifier une ligne supprimée.", Severity.Error);
                newLineDto.IsNew = listLine.Data.IsNew;
                newLineDto.IsModified = listLine.Data.IsModified;
                listLine.Data = newLineDto;
            }
        }

        private void RemoveLine(ShoppingListLineVM line)
        {
            _lines.Remove(line);
            var listLine = _linesUpdate.SingleOrDefault(x => x.LocalId == line.LocalId);
            if (listLine is null)
            {
                _linesUpdate.Add(new ShoppingListLineCreateUpdateVM(line.LocalId)
                {
                    Data = new ShoppingListLineCreateUpdateDto()
                    {
                        OriginArticleId = line.Data.OriginArticleId,
                        ShoppingListId = shoppingList.Id,
                        IsNew = false,
                        IsModified = false,
                        IsDeleted = true
                    }
                });
            }
            else
            {
                if (listLine.Data.IsNew)
                    _linesUpdate.Remove(listLine);
                else
                {
                    listLine.Data.IsDeleted = true;
                    listLine.Data.IsModified = false;
                }
            }
        }

        private void GoToList()
        {
            _navigation.NavigateTo("/shoppinglist/" + SourceUrl);
        }

        private async Task Save()
        {
            // TODO: appel API
            if (Id is null)
            {
                ShoppingListCreateDto createModel = shoppingList.ToCreateDto();
                Id = await _client.InsertAsync(createModel);
                shoppingList.Id = (Guid)Id;
                _navigation.NavigateTo($"/shoppinglist/page/{SourceUrl}/{Id}");
            }
            else
            {
                ShoppingListUpdateDto updateModel = shoppingList.ToUpdateDto();
                if (await _client.UpdateAsync(shoppingList.Id, updateModel))
                {
                    if (_hasChanges)
                    {
                        _linesUpdate = _linesUpdate.Where(x => x.Data.ArticleId != Guid.Empty).ToList();
                        if (_linesUpdate.Count > 0)
                        {
                            if (await _client.UpdateLinesAsync(_linesUpdate.Select(x => x.Data)))
                            {
                                _snackbar.Add("Liste mise à jour.", Severity.Success);
                                
                                await LoadData();
                            }
                            else
                                _snackbar.Add("Problème dans la mise à jour des lignes d'article.", Severity.Error);
                        }
                        else
                        {
                            _snackbar.Add("Aucune changement de ligne effectué mais liste mise à jour.", Severity.Info);
                        }
                    }
                }
                else
                    _snackbar.Add("Problème dans la mise à jour de la liste.", Severity.Error);
            }
        }

        private async Task Complete()
        {
            if (shoppingList.IsDone)
            {
                await _client.Complete(shoppingList.Id);
                await LoadData();
            }
            else
            {
                await Save();
                await _client.Complete(shoppingList.Id);
                await LoadData();
            }
        }

        public class ShoppingListLineVM
        {
            public Guid LocalId { get; set; } = Guid.NewGuid();
            public ShoppingListLineListDto Data { get; set; } = new();
        }
        public class ShoppingListLineCreateUpdateVM
        {
            public Guid LocalId { get; set; }
            public ShoppingListLineCreateUpdateDto Data { get; set; } = new();

            public ShoppingListLineCreateUpdateVM(Guid localId)
            {
                LocalId = localId;
            }
        }
    }
}
