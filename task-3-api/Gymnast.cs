namespace task_3_api
{
    public class Gymnast
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int day;

        public int Day
        {
            get { return day; }
            set { if (value > 0 && value < 7)
                    day = value;
                else day = 1;
            }
        }


     



    }
}
