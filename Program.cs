using System;
using System.IO;
using System.Linq;
namespace vpAssignment1
{
    class Student
    {
        int ID;
        string name;
        int semester;
        float CGPA;
        string department;
        string university;
        public int myID
        {
            get { return this.ID; }
            set { this.ID = value; }
        }
        public string myName
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int mySemester
        {
            get { return this.semester; }
            set { this.semester = value; }
        }
        public float myCGPA
        {
            get { return this.CGPA; }
            set { this.CGPA = value; }
        }
        public string myDepartment
        {
            get { return this.department; }
            set { this.department = value; }
        }
        public string myUniversity
        {
            get { return this.university; }
            set { this.university = value; }
        }
        public int lengthOfFile() //Function to Calculate Number of Lines in a Text File
        {
            string line; int length = 0;
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    length++;
                }
            }
            return length;
        }
        public void createStudentProfile() //Function to get user input for Student Profile
        {
            string line;
            Console.WriteLine("Enter Student ID: ");
            myID = Convert.ToInt32(Console.ReadLine());

            //Checking if the ID entered by the user already exist as ID must be unique
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt")) 
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(myID + " ")) 
                    {
                        Console.WriteLine("Error! ID already exits!");
                        System.Environment.Exit(0); //if ID already exists then Exit the Application
                    }
                }
            }
            Console.WriteLine("Enter Student Name: ");
            myName = Console.ReadLine();
            Console.WriteLine("Enter Student Semester: ");
            mySemester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student CGPA: ");
            myCGPA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Department: ");
            myDepartment = Console.ReadLine();
            Console.WriteLine("Enter Student University: ");
            myUniversity = Console.ReadLine();

            //Writing user input data of Student Profile into Text File
            using (StreamWriter sw = new StreamWriter(@"C:\Users\malik\OneDrive\Documents\data.txt", true))
            {
                sw.WriteLine(myID + " " + myName + " " + mySemester + " " + myCGPA + " " + myDepartment + " " + myUniversity);
            }
        }
        public void searchStudentByID(string key) //Function to Search Existing Record by ID
        {
            string line; int count = 0;
            string id = "", name = "", sem = "", cgpa = "", dpt = "", uni = "";
            bool flag = false;

            //Reading Existing Data from Text File
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(key))
                    {
                        flag = true; //if Record Exists enable flag variable
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == ' ')
                                count++; //Counting Number of Words from Line
                            else
                            {
                                //Saving all characters of each and every word in separate variables
                                if (count == 0) 
                                    id += line[i]; 
                                else if (count == 1)
                                    name += line[i];
                                else if (count == 2)
                                    sem += line[i];
                                else if (count == 3)
                                    cgpa += line[i];
                                else if (count == 4)
                                    dpt += line[i];
                                else if (count == 5)
                                    uni += line[i];
                            }
                        }
                    }
                }
            }
            if (flag != true) //if there is no record, flag remain disabled
            {
                Console.WriteLine("No Record Exist.");
            }
            else //if record exists then display it to the user
            {
                Console.WriteLine("\nStudent ID: {0} \nStudent Name: {1} \nStudent Semester: {2} \nStudent CGPA: {3} \nStudent Department: {4} \nStudent University: {5}", id, name, sem, cgpa, dpt, uni);
            }
        }
        public void searchStudentByName(string key) //Function to search existing Record by Name and display all records with the same Name
        {
            string line; int count = 0, length, j = 0;
            string id = "", name = "", sem = "", cgpa = "", dpt = "", uni = "";

            length = lengthOfFile();

            string[] record = new string[length];
            bool flag = false;
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt")) //Reading Data from File
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(key))
                    {
                        flag = true;
                        record[j] = line;
                        j++;
                    }
                }
            }
            if (flag != true) //if record doesn't exist
            {
                Console.WriteLine("No Record Exist.");
            }
            else //if record found, display it to the user
            {
                for (int i = 0; i < j; i++)
                {
                    string rec = record[i];
                    for (int k = 0; k < rec.Length; k++)
                    {
                        if (rec[k] == ' ')
                            count ++;
                        else
                        {
                            if (count == 0)
                                id += rec[k];
                            else if (count == 1)
                                name += rec[k];
                            else if (count == 2)
                                sem += rec[k];
                            else if (count == 3)
                                cgpa += rec[k];
                            else if (count == 4)
                                dpt += rec[k];
                            else if (count == 5)
                                uni += rec[k];
                        }
                    }
                    Console.WriteLine("\n----------------Record {0}----------------", i + 1);
                    Console.WriteLine("\nStudent ID: {0} \nStudent Name: {1} \nStudent Semester: {2} \nStudent CGPA: {3} \nStudent Department: {4} \nStudent University: {5}", id, name, sem, cgpa, dpt, uni);
                    count = 0; id = ""; name = ""; sem = ""; cgpa = ""; dpt = ""; uni = "";
                }
            }
        }
        public void listAllStudents() //Function to display all records
        {
            string line; int count = 0, length, j = 0;
            string id = "", name = "", sem = "", cgpa = "", dpt = "", uni = "";

            length = lengthOfFile();

            string[] record = new string[length];
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt")) //Reading data from Text File
            {
                while ((line = sr.ReadLine()) != null)
                {
                    record[j] = line;
                    j++;
                }
            }
            for (int i = 0; i < j; i++) //Displaying all records to the user
            {
                string rec = record[i];
                for (int k = 0; k < rec.Length; k++)
                {
                    if (rec[k] == ' ')
                        count++;
                    else
                    {
                        if (count == 0)
                            id += rec[k];
                        else if (count == 1)
                            name += rec[k];
                        else if (count == 2)
                            sem += rec[k];
                        else if (count == 3)
                            cgpa += rec[k];
                        else if (count == 4)
                            dpt += rec[k];
                        else if (count == 5)
                            uni += rec[k];
                    }
                }
                Console.WriteLine("\n----------------Record {0}----------------", i + 1);
                Console.WriteLine("\nStudent ID: {0} \nStudent Name: {1} \nStudent Semester: {2} \nStudent CGPA: {3} \nStudent Department: {4} \nStudent University: {5}", id, name, sem, cgpa, dpt, uni);
                count = 0; id = ""; name = ""; sem = ""; cgpa = ""; dpt = ""; uni = "";
            }

        }
        public void deleteStudentRecord(string key) //Function to delete record entered by user (It is based on ID)
        {
            string line; int length, i = 0, index = 0; bool flag = false;
            length = lengthOfFile();
            string[] records = new string[length];
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt")) //Reading data from text file
            {
                while ((line = sr.ReadLine()) != null)
                {
                    records[i] = line;
                    if (line.Contains(key))
                    {
                        index = i;
                        flag = true;
                    }
                    i++;
                }
            }
            if (flag == false) //if No Record found
            {
                Console.WriteLine("\nNo Record Found.");
            }
            else //if Record found, delete it and re-write modified data in text file
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\malik\OneDrive\Documents\data.txt"))
                {
                    sw.Write("");
                }
                for (int j = 0; j < length; j++)
                {
                    if (j != index)
                    {
                        using (StreamWriter sw = new StreamWriter(@"C:\Users\malik\OneDrive\Documents\data.txt", true))
                        {
                            sw.WriteLine(records[j]);
                        }
                    }
                }
                Console.WriteLine("\nRecord has been deleted.");
            }
        }
        public void listTop3Students() //Function to List Students with Highest GPA
        {
            string line; int count = 0, length, j = 0, index=0;
            string id = "", name = "", cgp = "";
            length = lengthOfFile();
            float[] cgpa = new float[length];
            string[] names = new string[length];
            int[] ids = new int[length];

            string[] record = new string[length];
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt")) //Reading data from text file
            {
                while ((line = sr.ReadLine()) != null)
                {
                    record[j] = line;
                    j++;
                }
            }
            for (int i = 0; i < j; i++) //Extracting Data
            {
                string rec = record[i];
                for (int k = 0; k < rec.Length; k++)
                {
                    if (rec[k] == ' ')
                        count++;
                    else
                    {
                        if (count == 0)
                            id += rec[k];
                        else if (count == 1)
                            name += rec[k];
                        else if (count == 3)
                            cgp += rec[k];
                    }
                }
                names[index] = name; //storing names in array
                ids[index] = Convert.ToInt32(id);  //storing ids in array
                cgpa[index] = float.Parse(cgp);  //storing cgpa in array
                index++;
                count = 0; id = ""; name = ""; cgp = ""; //resetting everything to 0 for next iteration
            }

            //Calculating highest, second highest and third highest CGPAs
            float max = cgpa[0];
            float secondMax = cgpa[1];
            float thirdMax = cgpa[2];
            int maxIndex = 0, secondMaxIndex = 0, thirdMaxIndex = 0;
            for (int i = 0; i < length; i++)
            {
                if (cgpa[i] > max)
                {
                    secondMax = max;
                    max = cgpa[i];
                    maxIndex = i;
                }
                if(cgpa[i] > secondMax && cgpa[i] != max)
                {
                    thirdMax = secondMax;
                    secondMax = cgpa[i];
                    secondMaxIndex = i;
                }
                if (cgpa[i] > thirdMax && (cgpa[i] != max && cgpa[i] != secondMax))
                {
                    thirdMax = cgpa[i];
                    thirdMaxIndex = i;
                }
            }
            //Displaying data of Top 3 Students to the user
            Console.WriteLine("\n-----1st Position Holder Details----- \nStudent Name: {0} \nStudent ID: {1} \nStudent CGPA: {2}", names[maxIndex], ids[maxIndex], max);
            Console.WriteLine("\n-----2nd Position Holder Details----- \nStudent Name: {0} \nStudent ID: {1} \nStudent CGPA: {2}", names[secondMaxIndex], ids[secondMaxIndex], secondMax);
            Console.WriteLine("\n-----3rd Position Holder Details---- - \nStudent Name: {0} \nStudent ID: {1} \nStudent CGPA: {2}", names[thirdMaxIndex], ids[thirdMaxIndex], thirdMax);
        }
        public void markAttendance() //Function to Mark attendance
        {
            string line; int count = 0, length, j = 0, index = 0;
            string id = "", name = "", choice = "N";
            
            length = lengthOfFile();
            string[] names = new string[length];
            string[] ids = new string[length];
            string[] attendances = new string[length];

            string[] record = new string[length];
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\data.txt")) //Reading data from text file
            {
                while ((line = sr.ReadLine()) != null)
                {
                    record[j] = line;
                    j++;
                }
            }
            for (int i = 0; i < j; i++) //Retrieving name and id of all students
            {
                string rec = record[i];
                for (int k = 0; k < rec.Length; k++)
                {
                    if (rec[k] == ' ')
                        count++;
                    else
                    {
                        if (count == 0)
                            id += rec[k];
                        else if (count == 1)
                            name += rec[k];
                    }
                }
                names[index] = name;
                ids[index] = id;
                index++;
                count = 0; id = ""; name = "";
            }
            
            for(int i = 0; i<length; i++) //User input to Mark Attendance
            {
                Console.WriteLine("\n{0}-ID: {1} Name: {2}", i+1, ids[i], names[i]);
                Console.WriteLine("Attendance (Present/Absent): ");
                attendances[i] = Console.ReadLine();
            }
            Console.WriteLine("\nDo you want to save the Attendance? (Y/N) \nPlease Enter your choice: "); //Asking to Save Attendance
            choice = Console.ReadLine();
            if(choice == "Y" || choice == "y")
            {
                //To Re-write Data in Text File to save one attendance record
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\malik\OneDrive\Documents\attendance.txt")) 
                    sw.Write("");
                }
                for (int i = 0; i < length; i++)
                {
                    //Saving Student name, id and attendance in separate text file 
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\malik\OneDrive\Documents\attendance.txt", true))
                    {
                        sw.WriteLine(ids[i] + " " + names[i] + " " + attendances[i]);
                    }
                }
                Console.WriteLine("\nYour Attendacne has been saved successfully.");
            }
            else
            {
                Console.WriteLine("\nWarning! You have not saved the Attendance, data will be loss.");
            }
        }
        public void viewAttendance() //Function to View Attendance
        {
            string line; int count = 0, length = 0, j = 0;
            string id = "", name = "", attendance = "";

            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\attendance.txt")) 
            {
                while ((line = sr.ReadLine()) != null)
                {
                    length++; //Counting number of lines
                }
            }

            string[] record = new string[length];
            using (StreamReader sr = new StreamReader(@"C:\Users\malik\OneDrive\Documents\attendance.txt")) //Reading from attendance text file
            {
                while ((line = sr.ReadLine()) != null)
                {
                    record[j] = line;
                    j++;
                }
            }
            for (int i = 0; i < j; i++) //Extracting Data
            {
                string rec = record[i];
                for (int k = 0; k < rec.Length; k++)
                {
                    if (rec[k] == ' ')
                        count++;
                    else
                    {
                        if (count == 0)
                            id += rec[k];
                        else if (count == 1)
                            name += rec[k];
                        else if (count == 2)
                            attendance += rec[k];
                    }
                }
                Console.WriteLine("\n{0}-ID: {1} Name: {2} Attendance: {3} ", i+1, id, name, attendance); //Displaying to user
                count = 0; id = ""; name = ""; attendance = "";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int choice, choice2;
            string choice3 = "N";
            string key;
            //Menu Creation
            Console.WriteLine("----------------WELCOME TO STUDENT MANAGEMENT SYSTEM----------------");
            Console.WriteLine("\nPlease Press \n1-Create Student Profile \n2-Search Student \n3-Delete Student Record \n4-List Top 3 Students of Class \n5-Mark Student Attendance \n6-View Attendance \n\nPlease Enter your Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Student obj = new Student();

            if (choice == 1)
            {
                obj.createStudentProfile();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Please Press \n1-To Search by ID \n2-To Search by Name \n3-To List All Students \n\nPlease Enter your Choice: ");
                choice2 = Convert.ToInt32(Console.ReadLine());
                if (choice2 == 1)
                {
                    Console.WriteLine("Enter ID to Search: ");
                    key = Console.ReadLine();
                    obj.searchStudentByID(key);
                }
                else if (choice2 == 2)
                {
                    Console.WriteLine("Enter Name to Search: ");
                    key = Console.ReadLine();
                    obj.searchStudentByName(key);
                }
                else if (choice2 == 3)
                {
                    obj.listAllStudents();
                }
                else
                {
                    Console.WriteLine("Error! Invalid Choice!");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter ID to Delete Record: ");
                key = Console.ReadLine();
                Console.WriteLine("\nDo you want to delete record? (Y/N) \nPlease Enter your Choice: "); //Confirming Deletion of Record
                choice3 = Console.ReadLine();
                if (choice3 == "y" || choice3 == "Y")
                    obj.deleteStudentRecord(key);
            }
            else if (choice == 4)
            {
                obj.listTop3Students();
            }
            else if (choice == 5)
            {
                obj.markAttendance();
            }
            else if (choice == 6)
            {
                obj.viewAttendance();
            }
            else
            {
                Console.WriteLine("Error!!! Invalid Choice!"); //Error message on invalid choice input 
            }
        }
    }
}
