using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMNoMessages
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
      public ICommand DeleteCommand { get; set; }
      public int Id { get; set; } = 2;
      private string output;
      public string Output
      {
         get { return output; }
         set
         {
            output = value;
            OnPropertyChanged();
         }
      }



      public MainPageViewModel()
      {

         DeleteCommand = new Command<int>(HandleDelete);
      }

      public event Action<int> DeleteEvent;

      public void HandleDelete(int Id)
         
      {
         DeleteEvent?.Invoke(Id);
      }

      public void DeleteRecord(int Id)
      {
         Output = String.Format($"Deleted {Id}");
      }
      public event PropertyChangedEventHandler PropertyChanged;


      protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }


   }
}
