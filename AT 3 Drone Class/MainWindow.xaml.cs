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

namespace AT_3_Drone_Class
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Global Lists and Queues
        private List<Drone> FinishedList = new List<Drone>();
        private Queue<Drone> RegularService = new Queue<Drone>();
        private Queue<Drone> ExpressService = new Queue<Drone>();
       // private int serviceTagCounter = 1;
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            #region comment 
            /*
            Create a separate class file to hold the data items of the Drone. Use separate getter and setter methods, ensure the attributes are private and the accessor methods are public. Add a display method that returns a string for Client Name and Service Cost. Add suitable code to the Client Name and Service Problem accessor methods so the data is formatted as Title case or Sentence case. Save the class as “Drone.cs”. 

            Create a global List<T> of type Drone called “FinishedList”.  

            Create a global Queue<T> of type Drone called “RegularService”. 

            Create a global Queue<T> of type Drone called “ExpressService”. 

            Create a button method called “AddNewItem” that will add a new service item to a Queue<> based on the priority. Use TextBoxes for the Client Name, Drone Model, Service Problem and Service Cost. Use a numeric control for the Service Tag. The new service item will be added to the appropriate Queue based on the Priority radio button. 

            Before a new service item is added to the Express Queue the service cost must be increased by 15%. 

            Create a custom method called “GetServicePriority” which returns the value of the priority radio group. This method must be called inside the “AddNewItem” method before the new service item is added to a queue. 

            Create a custom method that will display all the elements in the RegularService queue. The display must use a List View and with appropriate column headers. 

            Create a custom method that will display all the elements in the ExpressService queue. The display must use a List View and with appropriate column headers. 

            Create a custom method to ensure the Service Cost textbox can only accept a double value with two decimal point. 

            Create a custom method to increment the service tag control, this method must be called inside the “AddNewItem” method before the new service item is added to a queue. 

            Create a mouse click method for the regular service ListView that will display the Client Name and Service Problem in the related textboxes. 

            Create a mouse click method for the express service ListView that will display the Client Name and Service Problem in the related textboxes. 

            Create a button click method that will remove a service item from the regular ListView and dequeue the regular service Queue<T> data structure. The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items. 

            Create a button click method that will remove a service item from the express ListView and dequeue the express service Queue<T> data structure. The dequeued item must be added to the List<T> and displayed in the ListBox for finished service items. 

            Create a double mouse click method that will delete a service item from the finished listbox and remove the same item from the List<T>. 

            Create a custom method that will clear all the textboxes after each service item has been added. 
 */
            #endregion

            InitializeComponent();
            InitializeListViewColumns();

        }
        

        private void InitializeListViewColumns()
        {
            {
                lvRegularService.View = new GridView();
                ((GridView)lvRegularService.View).Columns.Add(new GridViewColumn { Header = "Client Name", DisplayMemberBinding = new Binding("ClientName") });
                ((GridView)lvRegularService.View).Columns.Add(new GridViewColumn { Header = "Service Problem", DisplayMemberBinding = new Binding("ServiceProblem") });

                lvExpressService.View = new GridView();
                ((GridView)lvExpressService.View).Columns.Add(new GridViewColumn { Header = "Client Name", DisplayMemberBinding = new Binding("ClientName") });
                ((GridView)lvExpressService.View).Columns.Add(new GridViewColumn { Header = "Service Problem", DisplayMemberBinding = new Binding("ServiceProblem") });
            }
        }




        

        private string GetServicePriority()
        {
            if (rbExpress.IsChecked == true)
            {
                return "Express";
            }
            else
            {
                return "Regular";
            }
        }


        private void DisplayExpressServiceQueue()
        {
            lvExpressService.Items.Clear();
            foreach (var item in ExpressService)
            {
                lvExpressService.Items.Add(item);
            }
        }

        private void DisplayRegularServiceQueue()
        {
            lvRegularService.Items.Clear();
            foreach (var item in RegularService)
            {
                lvRegularService.Items.Add(item);
            }
        }
        private void DisplayAllTextBoxes_Click(object sender, RoutedEventArgs e)
        {
            string message = $"Client Name: {txtClientName.Text}\n" +
                             $"Drone Model: {txtDroneModel.Text}\n" +
                             $"Service Problem: {txtServiceProblem.Text}\n" +
                             $"Service Cost: {txtServiceCost.Text}\n" +
                             $"Service Priority: {(rbExpress.IsChecked == true ? "Express" : "Regular")}";
            MessageBox.Show(message, "All Text Boxes");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           
        }

        
        // Programming Criteria 6.5
        private void btnAddNewItem_Click(object sender, RoutedEventArgs e)
        {
            
            /*
            if (string.IsNullOrWhiteSpace(txtServiceCost.Text) || !double.TryParse(txtServiceCost.Text, out double serviceCost))
            {
                MessageBox.Show("Please enter a valid number with 2 decimal places for the service cost.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClientName.Text) || string.IsNullOrWhiteSpace(txtDroneModel.Text) || string.IsNullOrWhiteSpace(txtServiceProblem.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var clientName = txtClientName.Text;
            var droneModel = txtDroneModel.Text;
            var serviceProblem = txtServiceProblem.Text;
            // Commenting out the service tag part as required
            // int serviceTag = int.Parse(txtServiceTag.Text);

            if (rbExpress.IsChecked == true)
            {
                serviceCost *= 1.15;
                var expressServiceItem = new Drone(clientName, droneModel, serviceProblem, serviceCost, 0);
                ExpressService.Enqueue(expressServiceItem);
                DisplayExpressServiceQueue();
            }
            else if (rbRegular.IsChecked == true)
            {
                var regularServiceItem = new Drone(clientName, droneModel, serviceProblem, serviceCost, 0);
                RegularService.Enqueue(regularServiceItem);
                DisplayRegularServiceQueue();
            }

            ClearFields();
            */
        }

        private int GenerateServiceTag()
        {
            return FinishedList.Count + RegularService.Count + ExpressService.Count + 1;
        }

        private void txtServiceCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if the text is a valid number
            if (!double.TryParse(txtServiceCost.Text, out double serviceCost))
            {
                // Clear the TextBox if it's not a valid number
                txtServiceCost.Text = "";
                return;
            }

            // Handle the logic for the service cost here, if needed
            // For example, you can update other UI elements based on the entered service cost
        }


        private void btnRemoveRegularService_Click(object sender, RoutedEventArgs e)
        {
            {
                if (RegularService.Count > 0)
                {
                    var removedItem = RegularService.Dequeue();
                    FinishedList.Add(removedItem);
                    DisplayRegularServiceQueue();
                    DisplayFinishedItems();
                }
            }
        }

        private void DisplayFinishedItems()
        {
            lbFinishedItems.Items.Clear();
            foreach (var drone in FinishedList)
            {
                lbFinishedItems.Items.Add(drone.Display());
            }
        }

        private void lbFinishedItems_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            lbFinishedItems.Items.Clear();
            foreach (var drone in FinishedList)
            {
                lbFinishedItems.Items.Add(drone);
            }
        }

        
    }
}