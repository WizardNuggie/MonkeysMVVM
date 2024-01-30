using MonkeysMVVM.Models;
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
            SearchByCountryCommand = new Command(FindMonkeys, () => country != null && country != string.Empty);
        }
        private void FindMonkeys()
        {
            
        }
    }
}
