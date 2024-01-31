using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class FindMonkeyByLocationPageViewModel:ViewModel
    {
        private string country;
        private int count;
        public string Country {  get { return country; } set {  country = value; OnPropertyChanged(); ((Command)SearchByCountryCommand).ChangeCanExecute(); } }
        public int Count { get { return count; } set { count = value; OnPropertyChanged(); } }
        public ICommand SearchByCountryCommand { get; set; }
        private Monkey monkey;
        public string Name { get { return monkey.Name; } }
        public string ImgaeUrl { get { return monkey.ImageUrl; } }
        public FindMonkeyByLocationPageViewModel()
        {
            monkey = new Monkey() { Name="No monkeys for now"};
            SearchByCountryCommand = new Command(FindMonkeys, () => !string.IsNullOrEmpty(country));
        }
        private void FindMonkeys()
        {
            MonkeysService service = new MonkeysService();
            List<Monkey> lst = service.FindMonkeyByLocation(country);
            if (lst.Count > 0)
                monkey = lst[0];
            else
            {
                monkey = new Monkey() { Name = "No monkeys for now"};
            }
            Count = lst.Count;
            RefreshData();
            Country = null;
        }
        private void RefreshData()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(ImgaeUrl));
        }
    }
}
