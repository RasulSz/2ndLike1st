using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfApp4.Commands;
using System.Collections.ObjectModel;
using WpfApp4.Models;
using WpfApp4.Repositories;

namespace WpfApp4.ViewModels
{
    public class MainWindowViewModels : BaseViewModel
    {

        private DataSet authorSet;

        public DataSet AuthorSet
        {
            get { return authorSet; }
            set { authorSet = value; OnPropertyChanged(); }
        }

        public Repository Authorss { get; set; }
        public RelayCommand InsertCommand { get; set; }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged(); }
        }

        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectionChanged { get; set; }


        public MainWindowViewModels()
        {

            Authorss = new Repository();
            AuthorSet = Authorss.GetAll();


            InsertCommand = new RelayCommand((obj) =>
            {
                Authorss.Insert(Id, FirstName, LastName);
            });
        }
    }
}
