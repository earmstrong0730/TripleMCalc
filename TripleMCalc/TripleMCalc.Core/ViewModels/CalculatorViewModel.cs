using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.ViewModels;

namespace TripleMCalc.Core

{
    public class CalculatorViewModel:MvxViewModel
	{
        List<int> numbers = new List<int>(); //initiliaze list that numbers will be added to

        int _numberList;
		public int NumberList
		{
			get { return _numberList; }
            set { _numberList = value; RaisePropertyChanged(() => NumberList); Recalculate(); }
		}
        //int _secondNumber;
        //public int SecondNumber
        //{
        //    get { return _secondNumber; }
        //    set { _secondNumber = value; RaisePropertyChanged(() => SecondNumber); Recalculate(); }
        //}
        double _mean;
		public double Mean
		{
			get { return _mean; }
			set { _mean = value; RaisePropertyChanged(() => Mean); }
		}
        int _mode;
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; RaisePropertyChanged(() => Mode); }
        }
        double _median;
        public double Median
        {
            get { return _median; }
            set { _median = value; RaisePropertyChanged(() => Median); }
        }

        void Recalculate()
        {

            for (int i = 0; i < NumberList; i++) //loop through the list of numbers that has been inputed and add them to number list
            {
                numbers.Add(i); 
            }
            numbers.Sort(); //put the list on ascending order
            int nc = numbers.Count();

            Mean = numbers.Sum() / numbers.Count(); //total the list and divide by the amouhnt of list items
            
            Mode = numbers.GroupBy(v => v) //group the numbers together by value
            .OrderByDescending(g => g.Count()) //order them by biggest group to smallest
            .First()//choose the first number in this group now and that is the number that occures the most times
            .Key;
        
            if (numbers.Count() % 2 != 0) //if amount of numbers is not even
            {
                Median = (double)(numbers[nc / 2]); //take the middle number
            }
            else //if amount of numbers is even
            {
                Median = (double)(numbers[(nc - 1) / 2 ] + numbers[nc / 2]) / 2; //add the two middle numbers and take their average
                
            }

        }
	}
}
