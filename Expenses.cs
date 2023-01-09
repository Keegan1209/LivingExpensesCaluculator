using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF1_POE
{
    public class Expenses
    {
        // Declaring private variables to be stored in system

        // user expense variables
        private double GrossIncome;

        private double TAXDeducted;
        private double ExGroceries;
        private double ExWaterLights;
        private double ExTravel;
        private double ExCell;
        private double ExOther;
        private double Available_Balance;

        // purchase or rent variables
        private double PurchasePrice;
        private double TotalDeposit;
        private double InterestRate;
        private double RepayMonths;
        private double MonthlyInstallments; // Monthly installments for renting or buying a property

        private double NewBalance;



        // Task 1 - stored expenses in array method
        //public double[] expenses = new double [5];

        //public String[] strArrayExp = { "Groceries: ", "Water & Lights: ", "Travel Cost: ", "Phone Bill: ", "Other Expenses: " };

        // TASK 2  implements genric List Dictionary to hold expenses



        //GET and SET methods to retrieve user input
        public static double grossIncome { get; set; }
        public static double taxDeducted
        { get; set; }
        public static double exGroceries
        { get; set; }
        public static double exWaterLights
        { get; set; }
        public static double exTravel
        { get; set; }
        public static double exCell
        { get; set; }
        public static double exOther
        { get; set; }

        public static double availableBalance
        { get; set; }
        //public double newBalance;

        public static double newBalance { get; set; }

        // purchase or rent property details

        public static double purchasePrice
        { get; set; }

        public static double totalDeposit
        { get; set; }

        public static double interestRate
        { get; set; }

        public static double repayMonths
        { get; set; }

        public static double monthlyInstallments
        { get; set; }


        private double VPurchasePrice;
        private double VDeposit;
        private double VInterest;
        private double VInsPremium;

        private double VCostUpdated;

        private double VMonthlyRepay;

        public double vRepayPeriod = 60;// repayments are done over a period of 5 Years (60 months)



        // Vehicle details
        public static double vPurchasePrice
        { get; set; }
        public static double vDeposit
        { get; set; }
        public static double vInterest
        { get; set; }

        public static double vInsPremium
        { get; set; }


        public static double vCostUpdated { get; set; }

        public static double vMonthlyRepay { get; set; }






        // double installments; //A
        //double P;
        // double i;
        // double n;
        private double ThirdIncome;
        public static double thirdIncome; /*=  Expenses.availableBalance / 3;
*/


        public static void CalcHomeLoan()
        {
            double installments; //A
            double P;
            double i;
            double n;

            P = Expenses.purchasePrice - Expenses.totalDeposit;
            i = Expenses.interestRate / 100;
            n = Expenses.repayMonths / 12;

            installments = P * (1 + i * n);

            Expenses.monthlyInstallments = installments / Expenses.repayMonths;
            Expenses.newBalance = Expenses.availableBalance - Expenses.monthlyInstallments;

            
        }

        public static void CalcRent()
        {
            Expenses.newBalance = (Expenses.availableBalance - Expenses.monthlyInstallments);
        }

        private double ExceededIncome;

        public static double exceededIncome { get; set; }


        private double VCalcMonthRepay;

        public static double vCalcMonthlyRepay { get; set; }


        private double VNewBalance;

        public static double vNewBalance { get; set; }


        public static void CalculateVehicleCost()
        {
            // update vehicle cost after deposit.
            Expenses.vCostUpdated = Expenses.vPurchasePrice - Expenses.vDeposit;

            double vP = vCostUpdated;
            double vI = vInterest / 100;
            double vN = 5;
            double vA;
            double vMonthlyPayment; 

            vA = vP * (1 + (vI * vN));

            vMonthlyPayment = vA / (vN * 12);


            Expenses.vCalcMonthlyRepay = vMonthlyPayment + Expenses.vInsPremium; 
            
            

            // equation to calculate monthly installments for vehicle
            //Expenses.vCalcMonthlyRepay = (Expenses.vCostUpdated / 60) * ((Expenses.vInterest / 100) + (Expenses.vInsPremium));

            Expenses.vNewBalance = Expenses.newBalance - Expenses.vCalcMonthlyRepay;


        }



        public static Dictionary<String, double> expensesDictionary = new Dictionary<string, double>();

        public static void ListExpenses()
        {
            // adds new values to list of monthly expenses



            // implements expenses dictionary generic function called in expenses class

            // first expenses
            expensesDictionary.Add("Groceries: ", exGroceries);
            expensesDictionary.Add("Water and Lights: ", exWaterLights);
            expensesDictionary.Add("Travel: ", exTravel);
            expensesDictionary.Add("cellphone: ", exCell);
            expensesDictionary.Add("Other: ", exOther);

            // new expenses
            expensesDictionary.Add("House Installments: ", monthlyInstallments);
            expensesDictionary.Add("Vehicle instalments: ", vCalcMonthlyRepay);
            expensesDictionary.Add("Insurance Premium: ", vInsPremium);


            //Console.WriteLine("\nExpenses Sorted in DESCENDING order");
            //Console.WriteLine("========================================");


            //sorts expenses in descending order
            //foreach (var item in expensesDictionary.OrderByDescending(Key => Key.Value))
            //{
            //    MessageBox.Show("{0} = {1} ", item.Key, item.Value);


            //}


        }


        private double SavingAmount;
        private double SavedAmount;
        private String SavingReason;
        private DateTime Date;
        //private double SavingPeriod;
        private double MonthlySavings; 


        public static String savingReason { get; set; }
        public static double savingAmount { get; set; }
        public static double savedAmount { get; set; }

        public static DateTime date { get; set; }

        //public static int savingPeriod { get; set; }

        public static  double monthlySavings { get; set; }

        public static void savings()
        {
            int Months;
            int savingPeriod;

            savingPeriod = Expenses.date.Year - DateTime.Now.Year;
            Months = savingPeriod * 12;


            savedAmount = Expenses.savingAmount * (1 + 0.05 * savingPeriod);

            monthlySavings = savedAmount / Months;

        }




        public Expenses(double grossIncome, double taxDeducted, double exGroceries, double exWaterLights, double exTravel, double exCell, double exOther, double availableBalance,
            double purchasePrice, double totalDeposit, double interestRate, double repayMonths, double monthlyInstallments, double newBalance,
            double vPurchasePrice, double vDeposit, double vInterest, double vInsPremium, double vCostUpdated, double vCalcMonthlyRepay, double exceededIncome, double thirdIncome,
            double vNewBalance, double savingAmount, double savedAmount, DateTime date, int savingPeriod, String savingReason)
        {
            GrossIncome = grossIncome;
            TAXDeducted = taxDeducted;
            ExGroceries = exGroceries;
            ExWaterLights = exWaterLights;
            ExTravel = exTravel;
            ExCell = exCell;
            ExOther = exOther;
            Available_Balance = availableBalance;

            NewBalance = newBalance; // new balance for homeloan Rent or Buy


            PurchasePrice = purchasePrice;
            TotalDeposit = totalDeposit;
            InterestRate = interestRate;
            RepayMonths = repayMonths;
            MonthlyInstallments = monthlyInstallments;


            VNewBalance = vNewBalance;// new balance for vehicle 
            VCalcMonthRepay = vCalcMonthlyRepay; 
            VPurchasePrice = vPurchasePrice;
            VDeposit = vDeposit;
            VInterest = vInterest;
            VInsPremium = vInsPremium;
            VCostUpdated = vCostUpdated;
            ExceededIncome = exceededIncome;

            ThirdIncome = thirdIncome; 

            SavingAmount = savingAmount;
            SavedAmount = savedAmount;
            Date = date;
            SavingReason = savingReason; 
            //SavingPeriod = savingPeriod; 

        }




    }
}
