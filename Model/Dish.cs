using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleResturantSystem.Model
{
    public class Dish : INotifyPropertyChanged
    {
        private int count;

        public Dish(string name, string photoUrl, int price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhotoUri = photoUrl ?? throw new ArgumentNullException(nameof(photoUrl));
            Price = price;
        }

        public string Name { get; set; }
        public string PhotoUri { get; set; }
        public int Price { get; set; }
        public int Count { get => count; set { count = value; OnPropertyChanged(); }  }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
