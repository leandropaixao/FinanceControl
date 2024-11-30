
using FinanceControl.Components.Layout.Interfaces;
using FinanceControl.Data.Repositories;
using FinanceControl.Models;
using Microsoft.AspNetCore.Components;

namespace FinanceControl.Pages.Entries;

public class EntriesRegisterViewBase : ComponentBase, IRegisterViewBase
{
    [Parameter]
    public Guid? Id { get; set; }
    [Inject]
    NavigationManager? NavigationManager { get; set; }

    protected Entry EntryData { get; set; } = new();

    [Parameter]
    public decimal TotalPaid //Corrigir aqui
    { 
        get => EntryData.Amount + EntryData.Interest - EntryData.Discount;
        set => EntryData.TotalPaid = EntryData.Amount + EntryData.Interest - EntryData.Discount;
    }

    protected override void OnInitialized()
    {
        if (Id != null)
        {
            var posting = EntriesRepository.Entries.FirstOrDefault(x => x.Id == Id);
            if (posting != null)
            {
                EntryData = posting;
            }
        }
    }

    public void Register()
    {
        if (Id == null)
        {
            EntriesRepository.AddEntry(EntryData);
        }
        else
        {
            EntriesRepository.EditEntry((Guid)Id, EntryData);
        }

        NavigationManager?.NavigateTo("/entries/list");
    }

    protected void OnValueChange() => EntryData.TotalPaid = EntryData.Amount + EntryData.Interest - EntryData.Discount;

}