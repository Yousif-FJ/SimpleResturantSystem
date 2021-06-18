using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleResturantSystem.Model
{
    public class Dish : INotifyPropertyChanged
    {
        private int count;

        public Dish()
        {

        }

        public Dish(string name, string photoUrl, int price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhotoName = photoUrl ?? throw new ArgumentNullException(nameof(photoUrl));
            Price = price;
        }

        public string Name { get; init; }
        public string PhotoName { get; init; }
        public int Price { get; init; }
        public int Count { get => count; set { count = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public Uri GetPhotoUri()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            return new Uri($"{basePath}\\Resource\\{PhotoName}");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
