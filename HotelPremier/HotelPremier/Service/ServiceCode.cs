using HotelPremier.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPremier.Service
{
    public class ServiceCode
    {       
        public vwWorker GetWorkerDetailsById(int userId)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {                    
                    vwWorker worker = (from p in context.vwWorkers where p.HotelUserId==userId select p).FirstOrDefault();
                    return worker;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public int GetManagerByFloorNumber(int floor)
        {
            int result = 0;
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {

                    result = (from p in context.Managers where p.HotelFloor == floor select p.ManagerId).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
            }
            return result;
        }

        public List<vwRequest> RequestListByWorker(int userId)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<vwRequest> list = new List<vwRequest>();
                    list = (from p in context.vwRequests select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
        public HotelUser LoginUser(string username, string password)
        {
            password = HashPasswordHelper.HashPassword(password);
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    HotelUser user = (from d in context.HotelUsers
                                       where d.Username.Equals(username)
                                       where d.Password.Equals(password)
                                       select d).FirstOrDefault();
                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

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

        public int GetManagerFlorByUserId(int userId)
        {
            int result=0;
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    
                    result = (from p in context.Managers where p.HotelUserId==userId select p.HotelFloor).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());                
            }
            return result;
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

        

        public List<vwWorker> GetAllWorkersByFloor(int floorNumber)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    List<vwWorker> list = new List<vwWorker>();
                    list = (from p in context.vwWorkers where p.HotelFloor==floorNumber select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
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
        

        public int AddNewRequest(Request request)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    if (request.RequestId == 0)
                    {
                        Request newRequest = new Request();
                        newRequest.StartDate = request.StartDate;
                        newRequest.EndDate = request.EndDate;
                        newRequest.Reason = request.Reason;
                        newRequest.WorkerId = request.WorkerId;
                        newRequest.ManagerId = request.ManagerId;
                        context.Requests.Add(newRequest);
                        context.SaveChanges();
                        request.RequestId = newRequest.RequestId;
                        return request.RequestId;
                    }
                    else
                    {
                        Request editRequest = (from p in context.Requests where p.RequestId == request.RequestId select p).First();
                        editRequest.Status = request.Status;
                        editRequest.Explanation = request.Explanation;
                        context.SaveChanges();
                        return request.RequestId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
        }


        public int AddHotelUser(HotelUser user)
        {
            string password = HashPasswordHelper.HashPassword(user.Password);
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    if (user.HotelUserId == 0)
                    {
                        HotelUser newHotelUser = new HotelUser();
                        newHotelUser.FullName = user.FullName;
                        newHotelUser.DateOfBirth = user.DateOfBirth;
                        newHotelUser.Email = user.Email;
                        newHotelUser.Username = user.Username;
                        newHotelUser.RoleId = user.RoleId;
                        newHotelUser.Password = password;
                        context.HotelUsers.Add(newHotelUser);
                        context.SaveChanges();
                        user.HotelUserId = newHotelUser.HotelUserId;
                        return user.HotelUserId;
                    }
                    else
                    {
                        HotelUser editUser = (from p in context.HotelUsers where p.HotelUserId == user.HotelUserId select p).First();
                        editUser.FullName = user.FullName;
                        editUser.DateOfBirth = user.DateOfBirth;
                        editUser.Email = user.Email;
                        editUser.Username = user.Username;
                        editUser.RoleId = user.RoleId;
                        editUser.HotelUserId = user.HotelUserId;
                        context.SaveChanges();
                        return user.HotelUserId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());                
                return 0;
            }
        }        

        public int AddNewManger(Manager user)
        {           
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    if (user.ManagerId == 0)
                    {
                        Manager newHotelManager = new Manager();
                        newHotelManager.HotelUserId = user.HotelUserId;
                        newHotelManager.HotelFloor = user.HotelFloor;
                        newHotelManager.WorkExperience = user.WorkExperience;
                        newHotelManager.QualificationLevelId = user.QualificationLevelId;
                        context.Managers.Add(newHotelManager);
                        context.SaveChanges();
                        user.ManagerId = newHotelManager.ManagerId;
                        return user.ManagerId;
                    }
                    else
                    {
                        Manager editManager = (from p in context.Managers where p.ManagerId == user.ManagerId select p).First();
                        editManager.HotelFloor = user.HotelFloor;
                        editManager.WorkExperience = user.WorkExperience;
                        editManager.QualificationLevelId = user.QualificationLevelId;
                        editManager.ManagerId = user.ManagerId;
                        context.SaveChanges();
                        return user.ManagerId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
        }

        public int AddNewWorker(Worker user)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    if (user.WorkerId == 0)
                    {
                        Worker newWorkerHotel = new Worker();
                        newWorkerHotel.HotelUserId = user.HotelUserId;
                        newWorkerHotel.HotelFloor = user.HotelFloor;
                        newWorkerHotel.Citizenship = user.Citizenship;
                        newWorkerHotel.GenderId = user.GenderId;
                        newWorkerHotel.EngagmentId = user.EngagmentId;
                        newWorkerHotel.QualificationLevelId = user.QualificationLevelId;
                        newWorkerHotel.Salary = 0;
                        newWorkerHotel.WorkExperience = user.WorkExperience;
                        newWorkerHotel.ManagerId = user.ManagerId;
                        context.Workers.Add(newWorkerHotel);
                        context.SaveChanges();
                        user.WorkerId = newWorkerHotel.WorkerId;
                        return user.WorkerId;
                    }
                    else
                    {
                        Worker editWorker = (from p in context.Workers where p.WorkerId == user.WorkerId select p).First();
                        editWorker.Salary = user.Salary;
                        context.SaveChanges();
                        return user.WorkerId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
        }

        public bool CheckUsername(string username)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    HotelUser hotelUser = (from d in context.HotelUsers where d.Username == username select d).FirstOrDefault();

                    if (hotelUser != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool CheckEmail(string email)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    HotelUser hotelUser = (from d in context.HotelUsers where d.Email == email select d).FirstOrDefault();

                    if (hotelUser != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool CheckHotelFloor(int floor)
        {
            try
            {
                using (HotelPremierEntities context = new HotelPremierEntities())
                {
                    Manager hotelManager = (from d in context.Managers where d.HotelFloor == floor select d).FirstOrDefault();

                    if (hotelManager != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}
