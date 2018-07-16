using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVMNoMessages
{
	public partial class MainPage : ContentPage
	{
      MainPageViewModel vm;
		public MainPage()
		{
			InitializeComponent();

      }

      private async void DeleteEventHandler(int Id)
      {
            var answer = await DisplayAlert(
               "Delete Record?", 
               $"Do you want to delete record {Id}?", 
               "Yes", 
               "No");
         if (answer==true)
         {
            vm.DeleteRecord(Id);
         }
      }

      protected override void OnAppearing()
      {
         base.OnAppearing();
         vm = new MainPageViewModel();
         BindingContext = vm;
         vm.DeleteEvent += DeleteEventHandler;
      }

   }
}
