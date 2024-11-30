
using FinanceControl.Components.Pages.Interfaces;
using FinanceControl.Data.Repositories;
using FinanceControl.Models;
using Microsoft.AspNetCore.Components;

namespace FinanceControl.Pages.Entries;

public class EntriesListViewBase : ComponentBase, IListViewBase<Entry>
{
    protected string TextToSearch { get; set; } = string.Empty;
    protected string Searched { get; set; } = string.Empty;
    protected int Counter { get; set; }

    protected List<Entry> EntriesList { get => DataResult(); }
    
    [Inject] NavigationManager? NavigationManager { get; set; }

    public List<Entry> DataResult() => EntriesRepository.Entries;

    public void Edit(Guid id) => NavigationManager?.NavigateTo($"/entries/edit/{id}");

    public void New() => NavigationManager?.NavigateTo("/entries/register");

    public void Remove(Guid id)
    {
        if (EntriesRepository.RemoveEntry(id))
        {
            Console.WriteLine("Posting removed with success");
        }
        else
        {
            Console.WriteLine("Account not removed");
        }
    }

    public void Search()
    {
        Counter = 0;
        Searched = TextToSearch;
    }
}