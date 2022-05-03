using CaseStudy.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;

namespace CaseStudy.Client.Pages
{
    public partial class Index
    {        
        public long BeerToDelete { get; set; } = 0;
        private Beer[] beers = default!;

        protected override async Task OnInitializedAsync()
        {
            await LoadBeerList();
            await base.OnInitializedAsync();
        }

        private async Task LoadBeerList()
        {
            var response = await Http.GetAsync("api/Beers");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Beer[]>();
                if (result is null)
                {
                    result = Array.Empty<Beer>();
                }
                beers = result;
            }
            else
            {
                throw new Exception("Unable to fetch beers. I guess Erik was thirsty");
            }
        }

        private async Task RemoveABeer(long id)
        {
            var response = await Http.DeleteAsync($"/Beer/{id}");
            if (response.IsSuccessStatusCode)
            {
                await LoadBeerList();
                SnackBar.Add($"Removed Beer with id: {id}");
            }
            else
            {
                SnackBar.Add($"Unable to remove Beer with id: {id}", Severity.Error);
            }
        }

        public void RowClicked(TableRowClickEventArgs<Beer> context)
        {
            Nav.NavigateTo($"beer/{context.Item.Id}");
        }
    }
}
