using CommunityToolkit.Mvvm.ComponentModel;
using GridDemo.Model;
using GridDemo.Service;
using System.Collections.ObjectModel;

namespace GridDemo.ViewModel;

public partial class CellData : ObservableObject
{
    private Person? originalData;

    private string name = "";
    private int age;

    [ObservableProperty]
    private bool isNameModified = false;

    [ObservableProperty]
    private bool isAgeModified = false;

    public CellData(Person person)
    {
        name = person.Name;
        age = person.Age;
        originalData = new Person { Name = person.Name, Age = person.Age };
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
            IsNameModified = originalData != null && name != originalData.Name;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            age = value;
            OnPropertyChanged();
            IsAgeModified = originalData != null && age != originalData.Age;
        }
    }
}

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<CellData> cellDatas;

    private readonly IUserDataService userDataSerivce;

    public MainViewModel(IUserDataService userDataSerivce)
    {
        this.userDataSerivce = userDataSerivce;
        var userDatas = userDataSerivce.GetUserDataList();
        cellDatas = new ObservableCollection<CellData>();
        foreach (var userData in userDatas)
        {
            cellDatas.Add(new CellData(userData));
        }
    }
}
