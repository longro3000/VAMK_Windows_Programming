using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment_4_1
{
    public interface Ihotel
    {
        String Name
        {
            get;
            set;
        }
        String ConstructionDate
        {
            get;
            set;
        }
        String Address
        {
            get;
            set;
        }
        int Stars
        {
            get;
            set;
        }
    }

    class hotel : Ihotel
    {
        private String name, constructionDate, address;
        private int stars;
        ArrayList RoomList = new ArrayList();
        ArrayList CustomerList = new ArrayList();

        public hotel(String name, String date, String address, int stars)
        {
            this.name = name;
            this.constructionDate = date;
            this.address = address;
            this.stars = stars;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length != 0)
                    name = value;
                name = "unknown";
            }
        }

        public string ConstructionDate
        {
            get
            {
                return constructionDate;
            }
            set
            {
                if (value.Length != 0)
                    constructionDate = value;
                constructionDate = "unknown";
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value.Length != 0)
                    address = value;
                address = "unknown";
            }
        }

        public int Stars
        {
            get
            {
                return stars;
            }
            set
            {
                if (value !=  0)
                    stars = value;
                stars = 0;
            }
        }

    }
}
