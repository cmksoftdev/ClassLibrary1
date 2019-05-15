namespace CaliburnDemo {
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        int i1;
        int i2;
        string str1;

        public int I1
        {
            get => i1;
            set
            {
                i1 = value;
                this.NotifyOfPropertyChange();
            }
        }

        public int I2
        {
            get => i2;
            set
            {
                i2 = value;
                this.NotifyOfPropertyChange();
            }
        }

        public string Str1
        {
            get => str1;
            set
            {
                str1 = value;
                this.NotifyOfPropertyChange();
            }
        }

        public void Click1()
        {
            I1 = 100;
            I2 = 200;
            Str1 = "Test";
        }
    }
}