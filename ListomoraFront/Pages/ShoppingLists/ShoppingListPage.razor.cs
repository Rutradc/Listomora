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

        private List<ShoppingListLineListDto> _lines = new();
        private ShoppingListLinesUpdateDto _linesUpdate = new ShoppingListLinesUpdateDto();
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
                shoppingList = await _client.GetByIdAsync((Guid)Id);
            _lines = shoppingList.ShoppingListLines?.ToList() ?? new();
            foreach (var line in _lines)
            {
                if (line.ArticleId != null)
                {
                    line.SelectedArticle = new ShoppingListLineArticleDto
                    {
                        Id = line.ArticleId,
                        Name = line.ArticleName
                    };
                }
            }
        }

        private async Task<IEnumerable<ShoppingListLineArticleDto>> SearchArticles(string value, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 1)
                return Enumerable.Empty<ShoppingListLineArticleDto>();

            // appel API
            return await _articleClient.Search(value);
        }

        private void OnArticleSelected(ShoppingListLineListDto line, ShoppingListLineArticleDto? article)
        {
            if (article == null)
                return;

            line.ArticleId = article.Id;
            line.ArticleName = article.Name;
            line.SelectedArticle = article;

            _hasChanges = true;
        }

        private void OnLineChanged(ShoppingListLineListDto line, object? value, string field)
        {
            switch (field)
            {
                case nameof(line.Amount):
                    line.Amount = (double?)value;
                    break;

                case nameof(line.Unit):
                    line.Unit = (UnitTypeEnum?)value;
                    break;

                case nameof(line.Price):
                    line.Price = (decimal?)value;
                    break;
            }

            ModifyLine(line);
            _hasChanges = true;
        }

        private void AddLine()
        {
            _lines.Add(new ShoppingListLineListDto());
            _linesUpdate.AddedLines.Add(new ShoppingListLineCreateUpdateDto());
        }

        private void ModifyLine(ShoppingListLineListDto line)
        {
            var newLine = new ShoppingListLineCreateUpdateDto()
            {
                ArticleId = line.ArticleId,
                ShoppingListId = shoppingList.Id,
                Amount = line.Amount,
                Unit = line.Unit,
                Price = line.Price,
            };

            var listLine = _linesUpdate.AddedLines.SingleOrDefault(x => x.ArticleId == line.ArticleId);

            if (listLine is null)
            {
                listLine = _linesUpdate.UpdatedLines.SingleOrDefault(x => x.ArticleId == line.ArticleId);
                if (listLine is not null)
                {
                    _linesUpdate.UpdatedLines.Remove(listLine);
                }
                _linesUpdate.UpdatedLines.Add(newLine);
            }
            else
            {
                _linesUpdate.AddedLines.Remove(listLine);
                _linesUpdate.AddedLines.Add(newLine);
            }
        }

        private void RemoveLine(ShoppingListLineListDto line)
        {
            _lines.Remove(line);
            var listLine = _linesUpdate.AddedLines.SingleOrDefault(x => x.ArticleId == line.ArticleId);
            if (listLine is null)
            {
                listLine = _linesUpdate.UpdatedLines.SingleOrDefault(x => x.ArticleId == line.ArticleId);
                if (listLine is not null)
                {
                    _linesUpdate.UpdatedLines.Remove(listLine);
                }
                _linesUpdate.RemovedLinesArticleIds.Add(line.ArticleId);
            }
            else
            {
                _linesUpdate.AddedLines.Remove(listLine);
            }
        }

        private void GoToList()
        {
            _navigation.NavigateTo("/shoppinglist/" + SourceUrl);
        }

        private async Task Save()
        {
            shoppingList.ShoppingListLines = _lines;

            // TODO: appel API
            if (Id is null)
            {
                ShoppingListCreateDto createModel = shoppingList.ToCreateDto();
                Id = await _client.InsertAsync(createModel);
                shoppingList.Id = (Guid)Id;
            }
            else
            {
                ShoppingListUpdateDto updateModel = shoppingList.ToUpdateDto();
                if (await _client.UpdateAsync(shoppingList.Id, updateModel))
                {
                    _linesUpdate.AddedLines = _linesUpdate.AddedLines.Where(x => x.ArticleId != Guid.Empty).ToList();
                    if (_linesUpdate != new ShoppingListLinesUpdateDto())
                    {
                        if (await _client.UpdateLinesAsync(_linesUpdate, shoppingList.Id))
                        {
                            _snackbar.Add("Liste mise à jour.", Severity.Success);
                            _linesUpdate = new ShoppingListLinesUpdateDto();
                        }
                        else
                            _snackbar.Add("Problème dans la mise à jour des lignes d'article.", Severity.Error);

                        //if (await _client.DeleteLinesAsync(_removedLinesArticleIds, shoppingList.Id))
                        //{
                        //    if (await _client.UpdateLineAsync)
                        //    if (await _client.InsertLinesAsync(_addedLines))
                        //        _snackbar.Add("Liste mise à jour.", Severity.Success);
                        //    else
                        //        _snackbar.Add("Problème dans l'ajout de ligne(s) d'article.", Severity.Error);
                        //}
                        //else
                        //    _snackbar.Add("Problème dans la suppression de ligne(s) d'article.", Severity.Error);
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
                shoppingList = await _client.GetByIdAsync((Guid)Id);
            }
            else
            {
                await Save();
                await _client.Complete(shoppingList.Id);
                shoppingList = await _client.GetByIdAsync((Guid)Id);
            }
        }
    }
}
