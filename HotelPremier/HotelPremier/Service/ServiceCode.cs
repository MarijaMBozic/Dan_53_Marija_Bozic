using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPremier.Service
{
    public class ServiceCode
    {
        public List<Gender> GetAllGender()
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<Gender> list = new List<Gender>();
                    list = (from p in context.Genders select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public List<Engagment> GetAllEngagment()
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<Engagment> list = new List<Engagment>();
                    list = (from p in context.Engagments select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public List<QualificationLevel> GetAllQualificationLevel()
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<QualificationLevel> list = new List<QualificationLevel>();
                    list = (from p in context.QualificationLevels select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public List<int> ListOfFloorsForManager()
        {
            List<int> result = new List<int>();
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<int> assignedFloors = (from a in context.vwManagers select a.HotelFloor).ToList();

                    for (int i = 1; i <= 25; i++)
                    {
                        if (!assignedFloors.Contains(i))
                        {
                            result.Add(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return result = null;
            }

            return result;
        }

        public List<int> ListOfFloorsForWorker()
        {
            List<int> result = new List<int>();
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<int> assignedFloors = (from a in context.vwManagers select a.HotelFloor).ToList();

                    foreach(int floor in assignedFloors)
                    {
                        result.Add(floor);
                    }                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return result = null;
            }

            return result;
        }
    }
}
