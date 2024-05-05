using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Virtual_Pet_V0._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PetModel model;
        private PetController controller;
        
        public MainWindow()
        {
            InitializeComponent();

            // Initialise the model
            model = new PetModel() { Name = "Fluffy", ImageSource = "Images/Fluffy.jpeg", Description = "Big fluffy dog with 3 heads", Happiness = 65, Hunger = 50, Thirst = 80};

            // Initialise the controller
            controller = new PetController(model, this);
        }

        // Event handler for the Feed button
        private void FeedButton_Click(object sender, RoutedEventArgs e)
        {
            controller.FeedPet();
        }

        // Event handler for the Water button
        private void WaterButton_Click(object sender, RoutedEventArgs e)
        {
            controller.WaterPet();
        }

        // Event handler for the Hunger button
        private void HungerButton_Click(Object sender, RoutedEventArgs e)
        {
            controller.HungerUpdate();
        }

        private void ThirstButton_Click(Object sender, RoutedEventArgs e)
        {
            controller.ThirstUpdate();
        }
    }

    // Model
    public class PetModel : INotifyPropertyChanged
    {
        private string name;
        private string imageSource;
        private string description;
        private int happiness;
        private int hunger;
        private int thirst;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public int Happiness
        {
            get { return happiness; }
            set
            {
                happiness = value;
                OnPropertyChanged(nameof(Happiness));
            }
        }

        public int Hunger
        {
            get { return hunger; }
            set
            {
                hunger = value;
                OnPropertyChanged(nameof(Hunger));
            }
        }

        public int Thirst
        {
            get { return thirst; }
            set
            {
                thirst = value;
                OnPropertyChanged(nameof(Thirst));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Controller
    public class PetController
    {
        private PetModel model;
        private MainWindow view;

        public PetController(PetModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
            this.view.DataContext = model; // Set data context to the model
        }

        // Interaction to handle methods and update the model
        public void FeedPet()
        {
            // Decrease hunger by feeding the pet
            model.Hunger += 10;

            // Increase happiness by feeding the pet
            model.Happiness += 10;
        }
        public void WaterPet()
        {
            // Decrease thirst by watering the pet
            model.Thirst += 5;

            // Increase happiness by watering the pet
            model.Happiness += 5;
        }
        public void HungerUpdate()
        {
            // Increase hunger
            model.Hunger -= 10;
            
            // Decrease happiness because the pet is hungry
            model.Happiness -= 10;
        }

        public void ThirstUpdate()
        {
            // Increase thirst
            model.Thirst -= 5;

            // Decrease happiness because the pet is thirsty
            model.Happiness -= 5;
        }
    }
}