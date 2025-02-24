using System.Reflection.Metadata.Ecma335;

class Sorter
{
    private IList<ISTAT_Details> male;
    private IList<ISTAT_Details> female;

    public Sorter(IList<ISTAT_Details> m, IList<ISTAT_Details> f)
    {
        this.male = m;
        this.female = f;
    }

    public void SortingAlg() {
        for(int i = 0; i < male.Count; i++)
        {
            ISTAT_Details moving = male[i];
            for (int j =0; j < i; j++)
            {
                ISTAT_Details Checking = male[j];

                if (String.Compare(moving.Name, Checking.Name) <0)
                {
                    // moving viene prima di checking
                    if(i> j)
                    {
                        //swap
                        swap_male(i, j);
                    }
                }

                if (String.Compare(moving.Name, Checking.Name) == 0)
                {
                    // movinguguale a checking
                }


                if (String.Compare(moving.Name, Checking.Name) > 0)
                {
                    // movinguguale viene dopo checking
                }
            }
        }

        for (int i = 0; i < female.Count; i++)
        {
            ISTAT_Details moving = female[i];
            for (int j = 0; j < male.Count; j++)
            {
                ISTAT_Details Checking = male[j];

                if (String.Compare(moving.Name, Checking.Name) < 0)
                {
                    // moving viene prima di checking
                        //swap
                        swap_female(i, j);
                    break;
                }

                if (String.Compare(moving.Name, Checking.Name) == 0)
                {
                    // movinguguale a checking
                }


                if (String.Compare(moving.Name, Checking.Name) > 0)
                {
                    // movinguguale viene dopo checking
                }
            }
        }
    }

    private void swap_male(int i, int j)
    {
        //memorizza la posizione i
        ISTAT_Details buffer = new();
        buffer.Year = male[i].Year;
        buffer.Name = male[i].Name;
        buffer.Count = male[i].Count;
        buffer.Gender = male[i].Gender;
        buffer.Percent = male[i].Percent;

        //metto checking in posizione i
        male[i].Year = male[j].Year;
        male[i].Name= male[j].Name;
        male[i].Count = male[j].Count;
        male[i].Gender = male[j].Gender;
        male[i].Percent = male[j].Percent;

        //metto buffer in posizione j
        male[j].Year = buffer.Year;
        male[j].Name = buffer.Name;
        male[j].Count = buffer.Count;
        male[j].Gender = buffer.Gender;
        male[j].Percent = buffer.Percent;
    }

    private void swap_female(int i, int j)
    {
        male.Insert(j, female[i]);

    }


}