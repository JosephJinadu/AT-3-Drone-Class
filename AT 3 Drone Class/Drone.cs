using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_3_Drone_Class
{

    // Programming Criteria 6.1
    // Create a separate class file to hold the data items of the Drone.
    // Use separate getter and setter methods, ensure the attributes are private and the accessor methods are public.
    // Add a display method that returns a string for Client Name and Service Cost.
    // Add suitable code to the Client Name and Service Problem accessor methods so the data is formatted as Title case or Sentence case.
    // Save the class as “Drone.cs”.
    internal class Drone()
    {


        private string clientName;
        private string droneModel;
        private string serviceProblem;
        private double serviceCost;
        private int serviceTag;

        public Drone(string _clientName, string _droneModel, string _serviceProblem, double _serviceCost, int _serviceTag) :this()
        {
            clientName = ToTitleCase(_clientName);
            droneModel = _droneModel;
            serviceProblem = ToSentenceCase(_serviceProblem);
            serviceCost = _serviceCost;
            serviceTag = _serviceTag;
        }

        // Getter and setter for ClientName
        public string GetClientName()
        {
            return clientName;
        }

        public void SetClientName(string newClientName)
        {
            clientName = ToTitleCase(newClientName);
        }

        // Getter and setter for DroneModel
        public string GetDroneModel()
        {
            return droneModel;
        }

        public void SetDroneModel(string newDroneModel)
        {
            droneModel = newDroneModel;
        }

        // Getter and setter for ServiceProblem
        public string GetServiceProblem()
        {
            return serviceProblem;
        }

        public void SetServiceProblem(string newServiceProblem)
        {
            serviceProblem = ToSentenceCase(newServiceProblem);
        }

        // Getter and setter for ServiceCost
        public double GetServiceCost()
        {
            return serviceCost;
        }

        public void SetServiceCost(double newServiceCost)
        {
            serviceCost = newServiceCost;
        }

        // Getter and setter for ServiceTag
        public int GetServiceTag()
        {
            return serviceTag;
        }

        public void SetServiceTag(int newServiceTag)
        {
            serviceTag = newServiceTag;
        }

        // Method to return a display string
        public string Display()
        {
            return $"Client Name: {clientName}, Service Cost: {serviceCost:C2}";
        }

        // Helper method to convert a string to title case
        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Helper method to convert a string to sentence case
        private string ToSentenceCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] array = input.ToCharArray();
            array[0] = char.ToUpper(array[0]);

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = char.ToLower(array[i]);
            }

            return new string(array);
        }

        public string GetDetails()
        {
            return $"Client Name: {clientName}, Drone Model: {droneModel}, Service Problem: {serviceProblem}, Service Cost: {serviceCost}";
        }
    }
}




        