namespace task_3_api
{

    public class DataContext
    {
        public List<Guide> Guides { get; set; }
        public List<Gymnast> Gymnasts { get; set; }
        public List<Lesson> Lessons { get; set; }
        public int numOfLessom { get; set; }
        public int Count1 { get; set; }
        public int Count { get; set; }

        public DataContext()
        {
            int count = 0;
            Guides = new List<Guide>()
        { new Guide() { Id = count++, FirstName = "Orly", LastName = "Ben Menachem", Days = new List<int>(){1,2,4} },
        new Guide() { Id=count++,FirstName="Ruth",LastName="Nankansky",Days= new List<int>() {2, 3, 5 }} };

            int count1 = 0;
            Gymnasts = new List<Gymnast>() { new Gymnast() { Id = count1++, FirstName = "sara", LastName = "kloyzner", Day = 3 },
        new Gymnast() { Id = count1++, FirstName = "Chana", LastName = "Cohen", Day = 6 },
        new Gymnast(){ Id = count1++, FirstName = "Yona", LastName = "Nachmani", Day = 9 }};

            numOfLessom = 0;
            Lessons = new List<Lesson>() {
            new Lesson() { Id=numOfLessom++,Day=1,CountOfWomen=10,Type="Eroby"},
         new Lesson() { Id=numOfLessom++,Day=4,CountOfWomen=12,Type="Yoge"}};
        }
        
    }
}
