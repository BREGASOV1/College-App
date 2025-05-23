using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_App
{
    public partial class Form1 : Form
    {


        public enum enGender { Male, Female };
        public enum enClass { class9, class10, class11, class12 };

        public enum enClassesForTeachers { class9, class10, class11, class12 };
        public enum enSpecialization { Scientific, Literature, Nothing };

        public int ID = 1;
        public int TeacherID = 1;

        public int[] ArabicCosts = new int[4] { 100, 150, 200, 200 };
        public int[] EnglishCosts = new int[4] { 50, 100, 150, 200 };
        public int[] FrenchCosts = new int[4] { 50, 100, 150, 200 };
        public int[] ReligionCosts = new int[4] { 20, 60, 100, 120 };
        public int[] MathCosts = new int[4] { 100, 150, 200, 300 };
        public int[] ScienceCosts = new int[4] { 100, 150, 200, 300 };
        public int[] PhysicsCosts = new int[4] { 100, 150, 200, 300 };
        public int[] ChemistryCosts = new int[4] { 100, 150, 200, 300 };
        public int[] PsychologyCosts = new int[4] { 0, 150, 200, 300 };
        public int[] GeographyCosts = new int[4] { 0, 100, 100, 190 };
        public int[] HistoryCosts = new int[4] { 0, 150, 180, 220 };
        public int HGDCosts = 100;

        public stStudent[] AllStudents = new stStudent[100];
        public stTeacher[] AllTeachers = new stTeacher[100];
        enum en9ClassCourses
        {
            Arabic = 2, English = 4, French = 8, Science = 16,
            Math = 32, Chemistry = 64, Religion = 128, Physics = 256, HGD = 512
        }

        enum enScientificCourses
        {
            Arabic = 2, English = 4, French = 8, Science = 16,
            Math = 32, Chemistry = 64, Religion = 128, Physics = 256
        }

        public enum enAllCourses
        {
            Arabic, English, French, Religion, Science, History,
            Math, Geography, Chemistry, Psychology, Physics, HGD
        }

        enum enLiteratureCourses
        {
            Arabic = 2, English = 4, French = 8, History = 16,
            Geography = 32, Psychology = 64, Religion = 128
        }

        public struct stStudent
        {
            public string DaysAsText;
            public string CoursesAsText;
            public byte ID;
            public enGender Gender;
            public string FirstName;
            public string MiddleName;
            public string LastName;
            public string Class;
            public enSpecialization Specialization;
            public int Courses;
            public int CoursesNumber;
            public int Days;
            public int DaysContent;
            public int TotalCosts;
            public int RemainedCosts;
            public DateTime EnrollmentDate;


        }



        public struct stTeacher
        {

            public enGender Gender;
            public enAllCourses Course;
            public string CourseName;
            public int Classes;
            public string FirstName;
            public string MiddleName;
            public string LastName;
            public string ClassesAsText;
            public int Salary;
            public string PreferredDaysAsText;
            public int RemainedSalary;
            public DateTime EnrollmentDate;

        }

        public stTeacher Teacher = new stTeacher();
        public stStudent Student = new stStudent();

        public ComboBox[] CoursesBoxes;

        public string[] ArabicTeachers = new string[15] {
            "Ali Mazen", "Bahaa Rami","", "","",
            "Alaa Hasan","Ehab Waleed","","","",
            "Yousef Manar", "Husam Manaa","","",""};
        public byte[] ArabicTeachersCount = new byte[3] { 2, 2, 2 };

        public string[] EnglishTeachers = new string[15]  {
            "Hadi Mazen", "Razan Rami","","","",
            "Azzam Malek","Malek Raman","","","",
            "Younes Tami", "Taimaa Walem","","",""};
        public byte[] EnglishTeachersCount = new byte[3] { 2, 2, 2 };


        public string[] FrenchTeachers = new string[15] {
            "Nabhan Gaffar", "Amera Talem", "", "", "",
            "Taleen Hasam", "Husam Talal", "", "", "",
            "Yasar Manar", "Deema Manaa","","",""   };
        public byte[] FrenchTeachersCount = new byte[3] { 2, 2, 2 };

        public string[] ReligionTeachers = new string[15] {
            "Qusay Betar", "Ola Fahad", "","", "",
            "Yasmin Rezk", "Yaser Ali", "", "", "",
            "Ali Manar", "Riham Manaa","","",""   };
        public byte[] ReligionTeachersCount = new byte[3] { 2, 2, 2 };

        public string[] MathTeachers = new string[15]{
            "Yaman Daki"  , "Suleman Mansour", "","", "",
            "Alia Moneer" , "Samer Ali", "", "", "",
            "Yamen Manar", "Ola Rannan","","",""};
        public byte[] MathTeachersCount = new byte[3] { 2, 2, 2 };


        public string[] PhysicsTeachers = new string[15] {
         "Murad Catar", "Kamel Ali", "","", "",
         "Rana Alkher", "Firas Jamel", "", "", "",
         "Taimaa Jameel", "Jameel Anmar","","",""};
        public byte[] PhysicsTeachersCount = new byte[3] { 2, 2, 2 };

        public string[] ChemistryTeachers = new string[15] {
            "Yasser Kanaan", "Hassan Hatem", "","", "",
            "Mofeda Ali", "Jameel Sameer", "", "", "",
            "Razan Kameel", "Kamel Mhran","","",""};
        public byte[] ChemistryTeachersCount = new byte[3] { 2, 2, 2 };

        public string[] ScienceTeachers = new string[15]{
            "Jihad Yasi", "Jaafar Talem", "", "", "",
            "Iman Ali", "Hani Noaman", "", "", "" ,
            "Yaser Manar", "Maher Zammam","","","" };
        public byte[] ScienceTeachersCount = new byte[3] { 2, 2, 2 };

        public string[] HistoryTeachers = new string[10]{
            "Ghassan Gaffar", "Roaa Yamen", "", "", "",
            "Yaroub Ali", "Ali Kamel", "", "", ""};
        public byte[] HistoryTeachersCount = new byte[2] { 2, 2 };

        public string[] GeographyTeachers = new string[10]{ "Laith Ahmad", "Zein Hayat", "","", "",
            "Somaya Ali", "Tamer Ali", "", "", "" };

        public byte[] GeographyTeachersCount = new byte[2] { 2, 2 };


        public string[] PsychologyTeachers = new string[10]{

            "Ruba Hasan", "Rasha Yousef", "", "", "",
            "Ibrahim Ihsan", "Ayman Taha","","",""
    };

        public byte[] PsychologyTeachersCount = new byte[2] { 2, 2 };

        public string[] HGDTeachers = new string[5] {
        "Kamal Jalen", "Sulaf Gned", "", "", ""};
        public byte HGDTeachersCount = 2;


        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Enabled = true;
            FillTreeViewCoursesTeachersClasses();
        }


        void FillTreeViewCoursesTeachersClasses()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    treeViewCoursesClassesTeachers.Nodes[i].Nodes[j].Nodes.Clear();
                }
            }
            for (int i = 8; i < 11; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    treeViewCoursesClassesTeachers.Nodes[i].Nodes[j].Nodes.Clear();
                }
            }
            treeViewCoursesClassesTeachers.Nodes[11].Nodes.Clear();

            TreeNode node = new TreeNode();
            for (int i = 10; i < 10 + ArabicTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[0].Nodes[0];
                node.Nodes.Add(ArabicTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 0; i < ArabicTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[0].Nodes[2];
                node.Nodes.Add(ArabicTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + ArabicTeachersCount[1]; i++)
            {
                node = treeViewCoursesClassesTeachers.Nodes[0].Nodes[1];
                node.Nodes.Add(ArabicTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < EnglishTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[1].Nodes[2];
                node.Nodes.Add(EnglishTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + EnglishTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[1].Nodes[1];
                node.Nodes.Add(EnglishTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + EnglishTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[1].Nodes[0];
                node.Nodes.Add(EnglishTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < FrenchTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[2].Nodes[2];
                node.Nodes.Add(FrenchTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + FrenchTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[2].Nodes[1];
                node.Nodes.Add(FrenchTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + FrenchTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[2].Nodes[0];
                node.Nodes.Add(FrenchTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < ReligionTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[3].Nodes[2];
                node.Nodes.Add(ReligionTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + ReligionTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[3].Nodes[1];
                node.Nodes.Add(ReligionTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + ReligionTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[3].Nodes[0];
                node.Nodes.Add(ReligionTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 0; i < MathTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[4].Nodes[2];
                node.Nodes.Add(MathTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + MathTeachersCount[1]; i++)
            {
                node = treeViewCoursesClassesTeachers.Nodes[4].Nodes[1];
                node.Nodes.Add(MathTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + MathTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[4].Nodes[0];
                node.Nodes.Add(MathTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < ScienceTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[5].Nodes[2];
                node.Nodes.Add(ScienceTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + ScienceTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[5].Nodes[1];
                node.Nodes.Add(ScienceTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + ScienceTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[5].Nodes[0];
                node.Nodes.Add(ScienceTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < ChemistryTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[6].Nodes[2];
                node.Nodes.Add(ChemistryTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + ChemistryTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[6].Nodes[1];
                node.Nodes.Add(ChemistryTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + ChemistryTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[6].Nodes[0];
                node.Nodes.Add(ChemistryTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < PhysicsTeachersCount[2]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[7].Nodes[2];
                node.Nodes.Add(PhysicsTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + PhysicsTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[7].Nodes[1];
                node.Nodes.Add(PhysicsTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 10; i < 10 + PhysicsTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[7].Nodes[0];
                node.Nodes.Add(PhysicsTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < HistoryTeachersCount[1]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[8].Nodes[1];
                node.Nodes.Add(HistoryTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + HistoryTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[8].Nodes[0];
                node.Nodes.Add(HistoryTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < GeographyTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[9].Nodes[1];
                node.Nodes.Add(GeographyTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + GeographyTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[9].Nodes[0];
                node.Nodes.Add(GeographyTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < PsychologyTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[10].Nodes[1];
                node.Nodes.Add(PsychologyTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;
            for (int i = 5; i < 5 + PsychologyTeachersCount[0]; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[10].Nodes[0];
                node.Nodes.Add(PsychologyTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

            for (int i = 0; i < HGDTeachersCount; i++)
            {

                node = treeViewCoursesClassesTeachers.Nodes[11];
                node.Nodes.Add(HGDTeachers[i]);
            }
            if (node.Nodes.Count == 5)
                node.ForeColor = Color.Red;

        }
        void StoreTeachersName(ComboBox SelectedTeacher)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(SelectedTeacher.SelectedItem)))
                SelectedTeacher.Tag = SelectedTeacher.SelectedItem.ToString();
        }

        void ResetTeacherName(ComboBox TeacherName)
        {

            TeacherName.Tag = "";
        }

        void ExtractSignedCourses(stStudent Student, TreeView StudentsTree)
        {
            TreeNode StudentName = new TreeNode(Student.FirstName + " " + Student.MiddleName + " " + Student.LastName);
            StudentsTree.Nodes.Add(StudentName);

            if ((Student.Courses & Convert.ToByte(enScientificCourses.Arabic)) == 2)
            {
                TreeNode Course = new TreeNode("Arabic");
                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxArabic.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.English)) == 4)
            {
                TreeNode Course = new TreeNode("English");
                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxEnglish.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.French)) == 8)
            {
                TreeNode Course = new TreeNode("French");
                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxFrench.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.Science)) == 16)
            {
                TreeNode Course;

                if (Student.Specialization == enSpecialization.Literature)
                    Course = new TreeNode("History");
                else
                    Course = new TreeNode("Science");


                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxScienceOrHistory.Tag));

            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.Math)) == 32)
            {
                TreeNode Course;

                if (Student.Specialization == enSpecialization.Literature)
                    Course = new TreeNode("Geography");
                else
                    Course = new TreeNode("Math");

                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxMathOrGeography.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.Chemistry)) == 64)
            {
                TreeNode Course;

                if (Student.Specialization == enSpecialization.Literature)
                    Course = new TreeNode("Psychology");
                else
                    Course = new TreeNode("Chemistry");

                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxChemistryOrPsychology.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.Religion)) == 128)
            {
                TreeNode Course = new TreeNode("Religion");
                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxReligion.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(enScientificCourses.Physics)) == 256)
            {
                TreeNode Course = new TreeNode("Physics");
                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(cboxPhysics.Tag));
            }
            if ((Student.Courses & Convert.ToInt16(en9ClassCourses.HGD)) == 512)
            {
                TreeNode Course = new TreeNode("HGD");
                StudentName.Nodes.Add(Course);
                Course.Nodes.Add(Convert.ToString(chboxHGD.Tag));
            }


        }

        void ResetPreferredDaysCheckBoxList(byte StudentOrTeacher)
        {
            if (StudentOrTeacher == 0)
            {
                while (chboxPreferredDays.CheckedIndices.Count > 0)
                    chboxPreferredDays.SetItemChecked(chboxPreferredDays.CheckedIndices[0], false);
                lbPreferredDays.Text = "Preferred Days";
            }
            else
            {
                while (chboxPreferredDaysTeachers.CheckedIndices.Count > 0)
                    chboxPreferredDaysTeachers.SetItemChecked(chboxPreferredDaysTeachers.CheckedIndices[0], false);
                lbPreferredDaysTeacher.Text = "Preferred Days";
            }
        }

        void Reset(byte TeacherOrStudent)
        {
            if (TeacherOrStudent == 0)
            {
                rdbFemale.Checked = false;
                rdbMale.Checked = false;
                rdbLiterature.Checked = false;
                rdbScientific.Checked = false;
                mtxtFirstName.Text = "";
                lbFirstName.Text = "First Name";
                mtxtMiddleName.Text = "";
                lbMiddleName.Text = "Middle Name";
                mtxtLastName.Text = "";
                lbLastName.Text = "Last Name";
                lbGender.Text = "Gender";
                lbSpecialization.Text = "Specialization";

                lbClass.Text = "Class";
                Student.Courses = 0;
                Student.CoursesNumber = 0;
                Student.Days = 0;
                Student.DaysContent = 0;
                Student.TotalCosts = 0;
                lbTotalCost.Text = "";
                lbCourses.Text = "Courses";

                cboxArabic.SelectedItem = cboxEnglish.SelectedItem = cboxFrench.SelectedItem = cboxScienceOrHistory.SelectedItem =
                    cboxMathOrGeography.SelectedItem = cboxChemistryOrPsychology.SelectedItem = cboxReligion.SelectedItem = cboxPhysics.SelectedItem =
                    chboxHGD.SelectedItem = comboBoxClass.SelectedItem = null;

                lblArabic.Text = "Course1";
                lblEnglish.Text = "Course2";
                lblFrench.Text = "Course3";
                lblScienceOrHistory.Text = "Course4";
                lblMathaOrGeography.Text = "Course5";
                lblChemistryOrPsychology.Text = "Course6";
                lblRelegion.Text = "Course7";
                lblPhysics.Text = "Course8";
                lblHGD.Text = "Course9";
                LockAll();
                chboxCourses.Items.Clear();

                ResetPreferredDaysCheckBoxList(0);
                Student.Days = 0;
            }
            else
            {
                rdbFemaleTeacher.Checked = false;
                rdbMaleTeacher.Checked = false;
                mtxtFirstNameTeacher.Text = "";
                lbFirstNameTeacher.Text = "First Name";
                mtxtMiddleNameTeacher.Text = "";
                lbMiddleNameTeacher.Text = "Middle Name";
                mtxtLastNameTeacher.Text = "";
                lbLastNameTeacher.Text = "Last Name";
                lbGenderTeacher.Text = "Gender";
                lbTeacherCourse.Text = "Course";
                mtxtSalary.Text = "";
                lbSalary.Text = "";
                ResetPreferredDaysCheckBoxList(1);
                for (int i = 0; i < 8; i++)

                {
                    LockDaysDatesComboBoxes(i);
                }
                cboxCourseTeachers.SelectedItem = null;
                chboxClassesTeachers.Items.Clear();
                mtxtIDTeacher.Text = Convert.ToString(TeacherID);
            }
        }

        public string GetClassName(enClass @class)
        {
            switch (@class)
            {
                case enClass.class9:

                    return "9";
                    break;
                case enClass.class10:
                    return "10 & 11";
                    break;
                case enClass.class12:
                    return "12";
                    break;

            }
            return null;
        }

        public string GetSpecializationName(enSpecialization Specialization)
        {
            switch (Specialization)
            {
                case enSpecialization.Scientific:
                    return "Scientific";
                    break;
                case enSpecialization.Literature:
                    return "Literature";
                    break;

            }
            return "";
        }

        void AddStudent(stStudent Student)
        {
            Student.RemainedCosts = Student.TotalCosts;
            Student.EnrollmentDate = DateTime.Now;
            AllStudents[ID] = Student;
            ListViewItem NewStudent = new ListViewItem(Convert.ToString(Student.ID));
            ExtractSignedCourses(Student, treeView2);
            if (Student.Gender == enGender.Male)
                NewStudent.ImageIndex = 0;
            else
                NewStudent.ImageIndex = 1;

            NewStudent.SubItems.Add(Student.FirstName);
            NewStudent.SubItems.Add(Student.MiddleName);
            NewStudent.SubItems.Add(Student.LastName);
            NewStudent.SubItems.Add(Student.Class);
            NewStudent.SubItems.Add(GetSpecializationName(Student.Specialization));
            NewStudent.SubItems.Add(Convert.ToString(Student.CoursesNumber));
            NewStudent.SubItems.Add(Convert.ToString(Student.TotalCosts));
            NewStudent.SubItems.Add(lbPreferredDays.Text);
            NewStudent.SubItems.Add(Convert.ToString(Student.RemainedCosts));
            NewStudent.SubItems.Add(Convert.ToString(Student.EnrollmentDate));


            listViewAllStudents.Items.Add(NewStudent);


        }

        void AddTeacher(stTeacher Teacher)
        {
            Teacher.EnrollmentDate = DateTime.Now;
            AllTeachers[ID] = Teacher;
            ListViewItem NewTeacher = new ListViewItem(Convert.ToString(TeacherID));
            if (Teacher.Gender == enGender.Male)
                NewTeacher.ImageIndex = 0;
            else
                NewTeacher.ImageIndex = 1;
            NewTeacher.SubItems.Add(Teacher.FirstName);
            NewTeacher.SubItems.Add(Teacher.MiddleName);
            NewTeacher.SubItems.Add(Teacher.LastName);
            NewTeacher.SubItems.Add(Teacher.CourseName);
            NewTeacher.SubItems.Add(Teacher.ClassesAsText);
            NewTeacher.SubItems.Add(Convert.ToString(Teacher.Salary));
            NewTeacher.SubItems.Add(Teacher.PreferredDaysAsText);
            NewTeacher.SubItems.Add(Convert.ToString(Teacher.RemainedSalary));
            NewTeacher.SubItems.Add(Convert.ToString(Teacher.EnrollmentDate));

            listViewAllTeachers.Items.Add(NewTeacher);
            TeacherID++;

        }

        void AddArabicTeacher(int ClassIndex)
        {

            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {
                switch (ClassIndex)
                {
                    case 0:
                        ArabicTeachersCount[0]++;
                        ArabicTeachers[9 + ArabicTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    case 1:
                        ArabicTeachersCount[1]++;
                        ArabicTeachers[4 + ArabicTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        ArabicTeachersCount[2]++;
                        ArabicTeachers[ArabicTeachersCount[2] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }

            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:
                        ArabicTeachers[9 + ArabicTeachersCount[0]] = "";
                        ArabicTeachersCount[0]--; ;

                        break;
                    case 1:

                        ArabicTeachers[4 + ArabicTeachersCount[1]] = "";
                        ArabicTeachersCount[1]--;

                        break;

                    case 2:
                        ArabicTeachersCount[2]--;
                        ArabicTeachers[ArabicTeachersCount[2]] = "";

                        break;

                }
            }

        }

        void AddEnglishTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {

                switch (ClassIndex)
                {
                    case 0:
                        EnglishTeachersCount[0]++;
                        EnglishTeachers[9 + EnglishTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    case 1:
                        EnglishTeachersCount[1]++;
                        EnglishTeachers[4 + EnglishTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        EnglishTeachersCount[2]++;
                        EnglishTeachers[EnglishTeachersCount[2] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        EnglishTeachers[9 + EnglishTeachersCount[0]] = "";
                        EnglishTeachersCount[0]--;
                        break;
                    case 1:

                        EnglishTeachers[4 + EnglishTeachersCount[1]] = "";
                        EnglishTeachersCount[1]--;
                        break;

                    case 2:
                        EnglishTeachersCount[2]--;
                        EnglishTeachers[EnglishTeachersCount[2]] = "";
                        break;

                }
            }
        }

        void AddFrenchTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {

                switch (ClassIndex)
                {
                    case 0:
                        FrenchTeachersCount[0]++;
                        FrenchTeachers[9 + FrenchTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    case 1:
                        FrenchTeachersCount[1]++;
                        FrenchTeachers[4 + FrenchTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        FrenchTeachersCount[2]++;
                        FrenchTeachers[FrenchTeachersCount[2] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        FrenchTeachers[9 + FrenchTeachersCount[0]] = "";
                        FrenchTeachersCount[0]--;
                        break;
                    case 1:

                        FrenchTeachers[4 + FrenchTeachersCount[1]] = "";
                        FrenchTeachersCount[1]--;
                        break;

                    case 2:
                        FrenchTeachersCount[2]--;
                        FrenchTeachers[FrenchTeachersCount[2]] = "";
                        break;

                }
            }
        }

        void AddReligionTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {

                switch (ClassIndex)
                {
                    case 0:
                        ReligionTeachersCount[0]++;
                        ReligionTeachers[9 + ReligionTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    case 1:
                        ReligionTeachersCount[1]++;
                        ReligionTeachers[4 + ReligionTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        ReligionTeachersCount[2]++;
                        ReligionTeachers[ReligionTeachersCount[2] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        ReligionTeachers[9 + ReligionTeachersCount[0]] = "";
                        ReligionTeachersCount[0]--;
                        break;
                    case 1:

                        ReligionTeachers[4 + ReligionTeachersCount[1]] = "";
                        ReligionTeachersCount[1]--;
                        break;

                    case 2:
                        ReligionTeachersCount[2]--;
                        ReligionTeachers[ReligionTeachersCount[2]] = "";
                        break;

                }
            }
        }

        void AddMathTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {

                switch (ClassIndex)
                {
                    case 0:
                        MathTeachersCount[0]++;
                        MathTeachers[9 + MathTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    case 1:
                        MathTeachersCount[1]++;
                        MathTeachers[4 + MathTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        MathTeachersCount[2]++;
                        MathTeachers[MathTeachersCount[1] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        MathTeachers[9 + MathTeachersCount[0]] = "";
                        MathTeachersCount[0]--;
                        break;
                    case 1:

                        MathTeachers[4 + MathTeachersCount[1]] = "";
                        MathTeachersCount[1]--;
                        break;

                    case 2:
                        MathTeachersCount[2]--;
                        MathTeachers[MathTeachersCount[2]] = "";
                        break;

                }
            }
        }

        void AddScienceTeacher(int ClassIndex)
        {

            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {

                switch (ClassIndex)
                {
                    case 0:
                        ScienceTeachersCount[0]++;
                        ScienceTeachers[9 + ScienceTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    case 1:
                        ScienceTeachersCount[1]++;
                        ScienceTeachers[4 + ScienceTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        ScienceTeachersCount[2]++;
                        ScienceTeachers[ScienceTeachersCount[2] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        ScienceTeachers[9 + ScienceTeachersCount[0]] = "";
                        ScienceTeachersCount[0]--;
                        break;
                    case 1:

                        ScienceTeachers[4 + ScienceTeachersCount[1]] = "";
                        ScienceTeachersCount[1]--;
                        break;

                    case 2:
                        ScienceTeachersCount[2]--;
                        ScienceTeachers[ScienceTeachersCount[2]] = "";
                        break;

                }
            }
        }

        void AddPhysicsTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {
                switch (ClassIndex)
                {
                    case 0:
                        PhysicsTeachersCount[0]++;
                        PhysicsTeachers[9 + PhysicsTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;

                        break;
                    case 1:
                        PhysicsTeachersCount[1]++;
                        PhysicsTeachers[4 + PhysicsTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        PhysicsTeachersCount[2]++;
                        PhysicsTeachers[PhysicsTeachersCount[0] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;
                }
            }
            else
            {

                switch (ClassIndex)
                {
                    case 0:

                        PhysicsTeachers[9 + PhysicsTeachersCount[0]] = "";
                        PhysicsTeachersCount[0]--;
                        break;
                    case 1:

                        PhysicsTeachers[4 + PhysicsTeachersCount[1]] = "";
                        PhysicsTeachersCount[1]--;
                        break;

                    case 2:
                        PhysicsTeachersCount[2]--;
                        PhysicsTeachers[PhysicsTeachersCount[2]] = "";
                        break;
                }
            }
        }

        void AddChemistryTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {
                switch (ClassIndex)
                {
                    case 0:
                        ChemistryTeachersCount[0]++;
                        ChemistryTeachers[9 + ChemistryTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;

                        break;
                    case 1:
                        ChemistryTeachersCount[1]++;
                        ChemistryTeachers[4 + ChemistryTeachersCount[1]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 2:
                        ChemistryTeachersCount[2]++;
                        ChemistryTeachers[ChemistryTeachersCount[2] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        ChemistryTeachers[9 + ChemistryTeachersCount[0]] = "";
                        ChemistryTeachersCount[0]--;
                        break;
                    case 1:

                        ChemistryTeachers[4 + ChemistryTeachersCount[1]] = "";
                        ChemistryTeachersCount[1]--;
                        break;

                    case 2:
                        ChemistryTeachersCount[2]--;
                        ChemistryTeachers[ChemistryTeachersCount[2]] = "";
                        break;

                }

            }
        }

        void AddHistoryTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {
                switch (ClassIndex)
                {
                    case 0:
                        HistoryTeachersCount[0]++;
                        HistoryTeachers[4 + HistoryTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 1:
                        HistoryTeachersCount[1]++;
                        HistoryTeachers[HistoryTeachersCount[1] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        HistoryTeachers[4 + HistoryTeachersCount[0]] = "";
                        HistoryTeachersCount[0]--;
                        break;

                    case 1:
                        HistoryTeachersCount[1]--;
                        HistoryTeachers[HistoryTeachersCount[1]] = "";
                        break;

                }
            }
        }

        void AddGeographyTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {
                switch (ClassIndex)
                {
                    case 0:
                        GeographyTeachersCount[0]++;
                        GeographyTeachers[4 + GeographyTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 1:
                        GeographyTeachersCount[1]++;
                        GeographyTeachers[GeographyTeachersCount[1] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        GeographyTeachers[4 + GeographyTeachersCount[0]] = "";
                        GeographyTeachersCount[0]--;
                        break;

                    case 1:
                        GeographyTeachersCount[1]--;
                        GeographyTeachers[GeographyTeachersCount[1]] = "";
                        break;

                }
            }
        }

        void AddPsychologyTeacher(int ClassIndex)
        {
            if (!chboxClassesTeachers.GetItemChecked(chboxClassesTeachers.SelectedIndex))
            {
                switch (ClassIndex)
                {
                    case 0:
                        PsychologyTeachersCount[0]++;
                        PsychologyTeachers[4 + PsychologyTeachersCount[0]] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                    case 1:
                        PsychologyTeachersCount[1]++;
                        PsychologyTeachers[PsychologyTeachersCount[1] - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;
                        break;

                }
            }
            else
            {
                switch (ClassIndex)
                {
                    case 0:

                        PsychologyTeachers[4 + PsychologyTeachersCount[0]] = "";
                        PsychologyTeachersCount[0]--;
                        break;
                    case 1:
                        PsychologyTeachersCount[1]--;
                        PsychologyTeachers[PsychologyTeachersCount[1]] = "";
                        break;

                }
            }

        }

        void AddHGDTeacher()
        {

            HGDTeachersCount++;
            HGDTeachers[HGDTeachersCount - 1] = mtxtFirstNameTeacher.Text + " " + mtxtLastNameTeacher.Text;

        }

        void AddTeachersCount(enAllCourses Course, int ClassIndex)
        {
            switch (Course)
            {
                case enAllCourses.Arabic:
                    AddArabicTeacher(ClassIndex);
                    break;
                case enAllCourses.English:
                    AddEnglishTeacher(ClassIndex);
                    break;
                case enAllCourses.French:
                    AddFrenchTeacher(ClassIndex);
                    break;
                case enAllCourses.Religion:
                    AddReligionTeacher(ClassIndex);
                    break;
                case enAllCourses.Science:
                    AddScienceTeacher(ClassIndex);
                    break;
                case enAllCourses.Math:
                    AddMathTeacher(ClassIndex);
                    break;
                case enAllCourses.Physics:
                    AddPhysicsTeacher(ClassIndex);
                    break;
                case enAllCourses.Chemistry:
                    AddChemistryTeacher(ClassIndex);
                    break;
                case enAllCourses.History:
                    AddHistoryTeacher(ClassIndex);
                    break;
                case enAllCourses.Geography:
                    AddGeographyTeacher(ClassIndex);
                    break;
                case enAllCourses.Psychology:
                    AddPsychologyTeacher(ClassIndex);
                    break;
                case enAllCourses.HGD:
                    AddHGDTeacher();
                    break;
                default:
                    break;
            }
        }

        string Get9CourseName(en9ClassCourses ClassCourses)
        {
            switch (ClassCourses)
            {
                case en9ClassCourses.Arabic:
                    return "Arabic";
                    break;
                case en9ClassCourses.Math:
                    return "Math";
                    break;
                case en9ClassCourses.Science:
                    return "Science";
                    break;
                case en9ClassCourses.Physics:
                    return "Physics";
                    break;
                case en9ClassCourses.Chemistry:
                    return "Chemistry";
                    break;
                case en9ClassCourses.English:
                    return "English";
                    break;
                case en9ClassCourses.French:
                    return "French";
                    break;
                case en9ClassCourses.HGD:
                    return "HGD";
                    break;
                case en9ClassCourses.Religion:
                    return "Religion";
                    break;

            }
            return "";
        }

        string GetScientificCourseName(enScientificCourses ScientificCourse)
        {
            switch (ScientificCourse)
            {
                case enScientificCourses.Arabic:
                    return "Arabic";
                    break;
                case enScientificCourses.English:
                    return "English";
                    break;
                case enScientificCourses.French:
                    return "French";
                    break;
                case enScientificCourses.Math:
                    return "Math";
                    break;
                case enScientificCourses.Science:
                    return "Science";
                    break;
                case enScientificCourses.Chemistry:
                    return "Chemistry";
                    break;
                case enScientificCourses.Physics:
                    return "Physics";
                    break;
                case enScientificCourses.Religion:
                    return "Religion";
                    break;


            }
            return "";
        }

        string GetLiteratureCourseName(enLiteratureCourses LiteratureCourse)
        {
            switch (LiteratureCourse)
            {
                case enLiteratureCourses.Arabic:
                    return "Arabic";
                    break;
                case enLiteratureCourses.English:
                    return "English";
                    break;
                case enLiteratureCourses.French:
                    return "French";
                    break;
                case enLiteratureCourses.Geography:
                    return "Geography";
                    break;
                case enLiteratureCourses.History:
                    return "History";
                    break;
                case enLiteratureCourses.Psychology:
                    return "Psychology";
                    break;
                case enLiteratureCourses.Religion:
                    return "Religion";
                    break;

            }



            return "";
        }

        void FillCoursesLabel(CheckedListBox Courses)
        {
            lbCourses.Text = "";
            for (int i = 0; i < Courses.CheckedItems.Count; i++)
            {
                lbCourses.Text += Courses.CheckedItems[i].ToString() + ", ";
            }
        }

        void FillTeachersLabels()
        {
            lblArabic.Text = "Arabic";
            lblEnglish.Text = "English";
            lblFrench.Text = "French";
            lblRelegion.Text = "Religion";
            if (rdbLiterature.Checked)
            {
                lbSpecialization.Tag = 1;
                lblScienceOrHistory.Text = "History";
                lblMathaOrGeography.Text = "Geography";
                lblChemistryOrPsychology.Text = "Psychology";
                lblPhysics.Enabled = false;
                FillCostsLabel10And11And12();
                return;

            }
            else if (rdbScientific.Checked)
            {
                lbSpecialization.Tag = 0;
                lblScienceOrHistory.Text = "Science";
                lblMathaOrGeography.Text = "Math";
                lblChemistryOrPsychology.Text = "Chemistry";
                lblPhysics.Text = "Physics";
                lblPhysics.Enabled = true;
                FillCostsLabel10And11And12();
                return;

            }
            else
            {
                lbSpecialization.Tag = 2;
                lblScienceOrHistory.Text = "Science";
                lblMathaOrGeography.Text = "Math";
                lblChemistryOrPsychology.Text = "Chemistry";
                lblPhysics.Text = "Physics";
                lblHGD.Text = "HGD";
            }

        }

        void ResetTeachersLabels()
        {

            lblArabic.Text = "Course1";
            lblEnglish.Text = "Course2";
            lblFrench.Text = "Course3";
            lblScienceOrHistory.Text = "Course4";
            lblMathaOrGeography.Text = "Course5";
            lblChemistryOrPsychology.Text = "Course6";
            lblRelegion.Text = "Course7";
            lblPhysics.Text = "Course8";
            lblPhysics.Enabled = true;


        }

        void ResetTeachersComboBoxes()
        {
            cboxArabic.Items.Clear();
            cboxEnglish.Items.Clear();
            cboxFrench.Items.Clear();
            cboxReligion.Items.Clear();
            cboxScienceOrHistory.Items.Clear();
            cboxMathOrGeography.Items.Clear();
            cboxChemistryOrPsychology.Items.Clear();
            cboxPhysics.Items.Clear();
            chboxHGD.Items.Clear();
        }

        void FillCostsLabels9()
        {

            lbArabicCost.Text = Convert.ToString(ArabicCosts[0]);
            lbEnglishCost.Text = Convert.ToString(EnglishCosts[0]);
            lbFrenchCost.Text = Convert.ToString(FrenchCosts[0]);
            lbReligionCost.Text = Convert.ToString(ReligionCosts[0]);
            lbMathGeographyCost.Text = Convert.ToString(MathCosts[0]);
            lbScienceHistoryCost.Text = Convert.ToString(ScienceCosts[0]);
            lbChemistryPsychologyCost.Text = Convert.ToString(ChemistryCosts[0]);
            lbPhysicCosts.Text = Convert.ToString(PhysicsCosts[0]);
            lbHGDCost.Text = Convert.ToString(HGDCosts);


        }

        void FillTeachersComboBoxes9()
        {
            FillCostsLabels9();
            for (int i = 10; i < 10 + ArabicTeachersCount[0]; i++)
            {
                cboxArabic.Items.Add(ArabicTeachers[i]);
            }
            for (int i = 10; i < 10 + EnglishTeachersCount[0]; i++)
            {
                cboxEnglish.Items.Add(EnglishTeachers[i]);
            }
            for (int i = 10; i < 10 + ReligionTeachersCount[0]; i++)
            {
                cboxReligion.Items.Add(ReligionTeachers[i]);
            }
            for (int i = 10; i < 10 + FrenchTeachersCount[0]; i++)
            {
                cboxFrench.Items.Add(FrenchTeachers[i]);
            }
            for (int i = 10; i < 10 + MathTeachersCount[0]; i++)
            {
                cboxMathOrGeography.Items.Add(MathTeachers[i]);
            }
            for (int i = 10; i < 10 + ScienceTeachersCount[0]; i++)
            {
                cboxScienceOrHistory.Items.Add(ScienceTeachers[i]);
            }
            for (int i = 10; i < 10 + ChemistryTeachersCount[0]; i++)
            {
                cboxChemistryOrPsychology.Items.Add(ChemistryTeachers[i]);
            }

            for (int i = 10; i <= 10 + PhysicsTeachersCount[0]; i++)
            {
                cboxPhysics.Items.Add(PhysicsTeachers[i]);
            }

            for (int i = 0; i < HGDTeachersCount; i++)
            {
                chboxHGD.Items.Add(HGDTeachers[i]);
            }
        }

        void FillCostsLabel10And11And12()
        {
            lbArabicCost.Text = Convert.ToString(ArabicCosts[comboBoxClass.SelectedIndex]);
            lbEnglishCost.Text = Convert.ToString(EnglishCosts[comboBoxClass.SelectedIndex]);
            lbFrenchCost.Text = Convert.ToString(FrenchCosts[comboBoxClass.SelectedIndex]);
            lbReligionCost.Text = Convert.ToString(ReligionCosts[comboBoxClass.SelectedIndex]);
            if (Student.Specialization == enSpecialization.Scientific)
            {
                lbMathGeographyCost.Text = Convert.ToString(MathCosts[comboBoxClass.SelectedIndex]);
                lbScienceHistoryCost.Text = Convert.ToString(ScienceCosts[comboBoxClass.SelectedIndex]);
                lbChemistryPsychologyCost.Text = Convert.ToString(ChemistryCosts[comboBoxClass.SelectedIndex]);
                lbPhysicCosts.Text = Convert.ToString(PhysicsCosts[comboBoxClass.SelectedIndex]);
                return;
            }
            if (Student.Specialization == enSpecialization.Literature)
            {
                lbMathGeographyCost.Text = Convert.ToString(GeographyCosts[comboBoxClass.SelectedIndex]);
                lbScienceHistoryCost.Text = Convert.ToString(HistoryCosts[comboBoxClass.SelectedIndex]);
                lbChemistryPsychologyCost.Text = Convert.ToString(PsychologyCosts[comboBoxClass.SelectedIndex]);

                return;
            }
            if (Student.Specialization == enSpecialization.Nothing)
                FillCostsLabels9();
        }

        void FillTeachersComboBoxes10and11()
        {
            for (int i = 5; i < 5 + ArabicTeachersCount[1]; i++)
            {
                cboxArabic.Items.Add(ArabicTeachers[i]);
            }
            for (int i = 5; i < 5 + EnglishTeachersCount[1]; i++)
            {
                cboxEnglish.Items.Add(EnglishTeachers[i]);
            }
            for (int i = 5; i < 5 + ReligionTeachersCount[1]; i++)
            {
                cboxReligion.Items.Add(ReligionTeachers[i]);
            }
            for (int i = 5; i < 5 + FrenchTeachersCount[1]; i++)
            {
                cboxFrench.Items.Add(FrenchTeachers[i]);
            }
            if (rdbLiterature.Checked)
            {
                for (int i = 5; i < 5 + GeographyTeachersCount[0]; i++)
                {
                    cboxMathOrGeography.Items.Add(GeographyTeachers[i]);
                }
                for (int i = 5; i < 5 + HistoryTeachersCount[0]; i++)
                {
                    cboxScienceOrHistory.Items.Add(HistoryTeachers[i]);
                }
                for (int i = 5; i < 5 + PsychologyTeachersCount[0]; i++)
                {
                    cboxChemistryOrPsychology.Items.Add(PsychologyTeachers[i]);
                }

                return;
            }
            if (rdbScientific.Checked)
            {
                for (int i = 5; i < 5 + MathTeachersCount[1]; i++)
                {
                    cboxMathOrGeography.Items.Add(MathTeachers[i]);
                }
                for (int i = 5; i < 5 + ScienceTeachersCount[1]; i++)
                {
                    cboxScienceOrHistory.Items.Add(ScienceTeachers[i]);
                }
                for (int i = 5; i < 5 + ChemistryTeachersCount[1]; i++)
                {
                    cboxChemistryOrPsychology.Items.Add(ChemistryTeachers[i]);
                }

                for (int i = 5; i < 5 + PhysicsTeachersCount[1]; i++)
                {
                    cboxPhysics.Items.Add(PhysicsTeachers[i]);
                }
                return;
            }

        }

        void FillTeachersComboBoxes12()
        {
            for (int i = 0; i < ArabicTeachersCount[2]; i++)
            {
                cboxArabic.Items.Add(ArabicTeachers[i]);
            }
            for (int i = 0; i < EnglishTeachersCount[2]; i++)
            {
                cboxEnglish.Items.Add(EnglishTeachers[i]);
            }
            for (int i = 0; i < ReligionTeachersCount[2]; i++)
            {
                cboxReligion.Items.Add(ReligionTeachers[i]);
            }
            for (int i = 0; i < FrenchTeachersCount[2]; i++)
            {
                cboxFrench.Items.Add(FrenchTeachers[i]);
            }
            if (rdbLiterature.Checked)
            {
                for (int i = 0; i < GeographyTeachersCount[1]; i++)
                {
                    cboxMathOrGeography.Items.Add(GeographyTeachers[i]);
                }
                for (int i = 0; i < HistoryTeachersCount[1]; i++)
                {
                    cboxScienceOrHistory.Items.Add(HistoryTeachers[i]);
                }
                for (int i = 0; i < PsychologyTeachersCount[1]; i++)
                {
                    cboxChemistryOrPsychology.Items.Add(PsychologyTeachers[i]);
                }

                return;
            }
            if (rdbScientific.Checked)
            {
                for (int i = 0; i < MathTeachersCount[2]; i++)
                {
                    cboxMathOrGeography.Items.Add(MathTeachers[i]);
                }
                for (int i = 0; i < ScienceTeachersCount[2]; i++)
                {
                    cboxScienceOrHistory.Items.Add(ScienceTeachers[i]);
                }
                for (int i = 0; i < ChemistryTeachersCount[2]; i++)
                {
                    cboxChemistryOrPsychology.Items.Add(ChemistryTeachers[i]);
                }

                for (int i = 0; i < PhysicsTeachersCount[2]; i++)
                {
                    cboxPhysics.Items.Add(PhysicsTeachers[i]);
                }
                return;
            }

        }

        void FillTeachersComboBoxes()
        {
            ResetTeachersComboBoxes();
            if (comboBoxClass.SelectedIndex == 0)
            {

                FillTeachersComboBoxes9();
                return;
            }
            if (comboBoxClass.SelectedIndex == 1 || comboBoxClass.SelectedIndex == 2)
            {

                FillTeachersComboBoxes10and11();
                return;
            }
            if (comboBoxClass.SelectedIndex == 3)
            {
                FillTeachersComboBoxes12();
                return;
            }


        }

        void AddDays(int index)
        {
            switch (index)
            {
                case 0:
                    Student.DaysContent |= 2;
                    Student.Days++;
                    break;
                case 1:
                    Student.DaysContent |= 4;
                    Student.Days++;
                    break;
                case 2:
                    Student.DaysContent |= 8;
                    Student.Days++;
                    break;
                case 3:
                    Student.DaysContent |= 16;
                    Student.Days++;
                    break;
                case 4:
                    Student.DaysContent |= 32;
                    Student.Days++;
                    break;
                case 5:
                    Student.DaysContent |= 64;
                    Student.Days++;
                    break;
                case 6:
                    Student.DaysContent |= 128;
                    Student.Days++;
                    break;

            }
        }

        void RemoveDays(int index)
        {
            switch (index)
            {
                case 0:
                    Student.DaysContent &= 252;
                    Student.Days--;
                    break;
                case 1:
                    Student.DaysContent &= 250;
                    Student.Days--;
                    break;
                case 2:
                    Student.DaysContent &= 246;
                    Student.Days--;
                    break;
                case 3:
                    Student.DaysContent &= 238;
                    Student.Days--;
                    break;
                case 4:
                    Student.DaysContent &= 222;
                    Student.Days--;
                    break;
                case 5:
                    Student.DaysContent &= 190;
                    Student.Days--;
                    break;
                case 6:
                    Student.DaysContent &= 126;
                    Student.Days--;
                    break;

            }

        }

        void LockDaysDatesComboBoxes(int index)
        {
            switch (index)
            {
                case 0:
                    cboxSunday.Enabled = false;
                    cboxSunday.SelectedItem = null;
                    break;
                case 1:
                    cboxMonday.Enabled = false;
                    cboxMonday.SelectedItem = null;
                    break;
                case 2:
                    cboxTuesday.Enabled = false;
                    cboxTuesday.SelectedItem = null;
                    break;
                case 3:
                    cboxWednesday.Enabled = false;
                    cboxWednesday.SelectedItem = null;
                    break;
                case 4:
                    cboxThursday.Enabled = false;
                    cboxThursday.SelectedItem = null;
                    break;
                case 5:
                    cboxFriday.Enabled = false;
                    cboxFriday.SelectedItem = null;
                    break;
                case 6:
                    cboxSaturday.Enabled = false;
                    cboxSaturday.SelectedItem = null;
                    break;
            }
        }

        void UnlockDaysDatesComboBoxes(int index)
        {
            switch (index)
            {
                case 0:
                    cboxSunday.Enabled = true;
                    break;
                case 1:
                    cboxMonday.Enabled = true;
                    break;
                case 2:
                    cboxTuesday.Enabled = true;
                    break;
                case 3:
                    cboxWednesday.Enabled = true;
                    break;
                case 4:
                    cboxThursday.Enabled = true;
                    break;
                case 5:
                    cboxFriday.Enabled = true;
                    break;
                case 6:
                    cboxSaturday.Enabled = true;
                    break;
            }
        }

        void ResetDaysDatesComboBoxes()
        {
            for (int i = 0; i < 7; i++)
            {
                LockDaysDatesComboBoxes(i);

            }
        }


        void LockTeachersComboBoxes(int index)
        {
            switch (index)
            {
                case 0:
                    Student.Courses &= 764;
                    Student.CoursesNumber--;
                    Student.TotalCosts -= Convert.ToInt32(lbArabicCost.Text);
                    cboxArabic.Enabled = false;
                    break;
                case 1:
                    Student.Courses &= 762;
                    Student.CoursesNumber--;
                    Student.TotalCosts -= Convert.ToInt32(lbEnglishCost.Text);
                    cboxEnglish.Enabled = false;
                    break;
                case 2:
                    Student.Courses &= 758;
                    Student.CoursesNumber--;
                    Student.TotalCosts -= Convert.ToInt32(lbFrenchCost.Text);
                    cboxFrench.Enabled = false;
                    break;
                case 3:
                    Student.Courses &= 750;
                    Student.CoursesNumber--;
                    Student.TotalCosts -= Convert.ToInt32(lbScienceHistoryCost.Text);
                    cboxScienceOrHistory.Enabled = false;
                    break;
                case 4:
                    Student.Courses &= 734;
                    Student.CoursesNumber--;
                    Student.TotalCosts += Convert.ToInt32(lbMathGeographyCost.Text);
                    cboxMathOrGeography.Enabled = false;
                    break;
                case 5:
                    Student.Courses &= 702;
                    Student.CoursesNumber--;
                    Student.TotalCosts += Convert.ToInt32(lbChemistryPsychologyCost.Text);
                    cboxChemistryOrPsychology.Enabled = false;
                    break;
                case 6:
                    Student.Courses &= 638;
                    Student.CoursesNumber--;
                    Student.TotalCosts += Convert.ToInt32(lbReligionCost.Text);
                    cboxReligion.Enabled = false;
                    break;
                case 7:
                    Student.Courses &= 510;
                    Student.CoursesNumber--;
                    Student.TotalCosts += Convert.ToInt32(lbPhysicCosts.Text);
                    cboxPhysics.Enabled = false;
                    break;
                case 8:
                    Student.Courses &= 254;
                    Student.CoursesNumber--;
                    Student.TotalCosts += Convert.ToInt32(lbHGDCost.Text);
                    chboxHGD.Enabled = false;
                    break;


            }
            lbTotalCost.Text = Convert.ToString(Student.TotalCosts);
        }

        void UnlockTeachersComboBoxes(int index)
        {

            switch (index)
            {
                case 0:
                    Student.Courses |= 2;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbArabicCost.Text);
                    cboxArabic.Enabled = true;
                    break;
                case 1:
                    Student.Courses |= 4;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbEnglishCost.Text);
                    cboxEnglish.Enabled = true;
                    break;
                case 2:
                    Student.Courses |= 8;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbFrenchCost.Text);
                    cboxFrench.Enabled = true;
                    break;
                case 3:
                    Student.Courses |= 16;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbScienceHistoryCost.Text);
                    cboxScienceOrHistory.Enabled = true;
                    break;
                case 4:
                    Student.Courses |= 32;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbMathGeographyCost.Text);
                    cboxMathOrGeography.Enabled = true;
                    break;

                case 5:
                    Student.Courses |= 64;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbChemistryPsychologyCost.Text);
                    cboxChemistryOrPsychology.Enabled = true;
                    break;

                case 6:
                    Student.Courses |= 128;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbReligionCost.Text);
                    cboxReligion.Enabled = true;
                    break;
                case 7:
                    Student.Courses |= 256;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbPhysicCosts.Text);
                    cboxPhysics.Enabled = true;
                    break;
                case 8:
                    Student.Courses |= 512;
                    Student.CoursesNumber++;
                    Student.TotalCosts += Convert.ToInt32(lbHGDCost.Text);
                    chboxHGD.Enabled = true;
                    break;


            }
            lbTotalCost.Text = Convert.ToString(Student.TotalCosts);
        }

        void LockAll()
        {

            cboxArabic.Enabled = false;

            cboxEnglish.Enabled = false;

            cboxFrench.Enabled = false;

            cboxScienceOrHistory.Enabled = false;

            cboxMathOrGeography.Enabled = false;

            cboxChemistryOrPsychology.Enabled = false;

            cboxReligion.Enabled = false;

            cboxPhysics.Enabled = false;

            chboxHGD.Enabled = false;



        }

        void FillTeacherCardLabels(MaskedTextBox Text)
        {
            switch (Convert.ToByte(Text.Tag))
            {
                case 1:
                    lbIDTeacher.Text = Text.Text;
                    break;
                case 2:
                    lbFirstNameTeacher.Text = Text.Text;
                    break;
                case 3:
                    lbMiddleNameTeacher.Text = Text.Text;
                    break;
                case 4:
                    lbLastNameTeacher.Text = Text.Text;
                    break;

            }
        }
        void FillStudentCardLabels(MaskedTextBox Text)
        {
            switch (Convert.ToByte(Text.Tag))
            {
                case 1:
                    lbID.Text = mtxtID.Text;
                    break;
                case 2:
                    lbFirstName.Text = mtxtFirstName.Text;
                    break;
                case 3:
                    lbMiddleName.Text = mtxtMiddleName.Text;
                    break;
                case 4:
                    lbLastName.Text = mtxtLastName.Text;
                    break;

            }
        }

        void FillClassCourses()
        {


            if (!lbSpecialization.Visible)
            {
                FillTeachersLabels();
                for (int i = 2; i <= 512; i *= 2)
                {

                    chboxCourses.Items.Add(Get9CourseName((en9ClassCourses)i));

                }
                return;
            }
            if (rdbScientific.Checked)
            {
                for (int i = 2; i <= 256; i *= 2)
                {

                    chboxCourses.Items.Add(GetScientificCourseName((enScientificCourses)i));

                }

            }
            else if (rdbLiterature.Checked)
            {
                for (int i = 2; i <= 128; i *= 2)
                {

                    chboxCourses.Items.Add(GetLiteratureCourseName((enLiteratureCourses)i));

                }


            }

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            FillStudentCardLabels((MaskedTextBox)sender);
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LockAll();
            Student.Days = 0;
            Student.DaysContent = 0;
            rdbLiterature.Checked = false;
            rdbScientific.Checked = false;
            lbSpecialization.Text = "Specialization";
            lbClass.Text = Convert.ToString(comboBoxClass.SelectedItem);
            Student.Class = Convert.ToString(comboBoxClass.SelectedItem);
            lbCourses.Text = "";
            Student.Courses = 0;
            Student.CoursesNumber = 0;
            chboxCourses.Items.Clear();
            ResetTeachersComboBoxes();
            ResetTeachersLabels();
            if (comboBoxClass.SelectedIndex == 0)
            {
                lblHGD.Visible = true;
                chboxHGD.Visible = true;
                chboxHGD.Enabled = false;
                lbSpecialization.Visible = false;
                panel2.Visible = false;
                lbHGDCost.Visible = true;
                FillClassCourses();
                FillTeachersComboBoxes9();
            }
            else
            {
                lblHGD.Visible = false;
                chboxHGD.Visible = false;
                lbSpecialization.Visible = true;
                panel2.Visible = true;
                lbHGDCost.Visible = false;

            }

        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            lbGender.Text = ((RadioButton)sender).Text;
            if (lbGender.Text == "Male")
                lbGender.Tag = 0;
            if (lbGender.Text == "Female")
                lbGender.Tag = 1;

        }

        private void rdbScientific_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLiterature.Checked)
                Student.Specialization = enSpecialization.Literature;
            else
                Student.Specialization = enSpecialization.Scientific;
            lbCourses.Text = "";
            FillTeachersComboBoxes();
            FillClassCourses();
            FillTeachersLabels();

            LockAll();
            Student.Courses = 0;
            Student.Days = 0;
            Student.DaysContent = 0;
            Student.CoursesNumber = 0;
            lbSpecialization.Text = ((RadioButton)sender).Text;
        }

        private void chboxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillCoursesLabel((CheckedListBox)sender);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mtxtID.Text = ID.ToString();
            mtxtIDTeacher.Text = TeacherID.ToString();
        }

        private void FillPreferredDaysLabel(CheckedListBox Days, byte TeacherOrStudent)
        {

            Label DaysLabel = (TeacherOrStudent == 0) ? lbPreferredDays : lbPreferredDaysTeacher;
            DaysLabel.Text = "";
            for (int i = 0; i < Days.CheckedItems.Count; i++)
            {
                DaysLabel.Text += Days.CheckedItems[i].ToString() + ", ";
            }
        }

        private void chboxPreferredDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPreferredDaysLabel((CheckedListBox)sender, 0);
        }

        private void chboxCourses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!(chboxCourses.GetItemChecked(chboxCourses.SelectedIndex)))
                UnlockTeachersComboBoxes(chboxCourses.SelectedIndex);
            else
                LockTeachersComboBoxes(chboxCourses.SelectedIndex);


        }

        void SaveStudent()
        {
            Student.CoursesAsText = lbCourses.Text;
            Student.DaysAsText = lbPreferredDays.Text;
            Student.ID = Convert.ToByte(mtxtID.Text);

            Student.Specialization = (enSpecialization)lbSpecialization.Tag;
            Student.Gender = (enGender)lbGender.Tag;
            Student.FirstName = mtxtFirstName.Text;
            Student.MiddleName = mtxtMiddleName.Text;
            Student.LastName = mtxtLastName.Text;
            AddStudent(Student);
        }

        void SaveTeacher()
        {

            Teacher.FirstName = mtxtFirstNameTeacher.Text;
            Teacher.MiddleName = mtxtMiddleNameTeacher.Text;
            Teacher.LastName = mtxtLastNameTeacher.Text;
            Teacher.ClassesAsText = lbClassesTeachers.Text;
            Teacher.CourseName = lbTeacherCourse.Text;
            Teacher.PreferredDaysAsText = lbPreferredDaysTeacher.Text;
            Teacher.RemainedSalary = Teacher.Salary;
            AllTeachers[TeacherID] = Teacher;
            AddTeacher(Teacher);



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if((rdbFemale.Checked == false&& rdbMale.Checked == false) 
              || mtxtFirstName.Text == null
                || mtxtMiddleName == null || mtxtLastName.Text == null
                || comboBoxClass.SelectedItem == null ||chboxCourses.SelectedItem == null
               )
            {
                MessageBox.Show("Please Fill All required fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (MessageBox.Show($"Are you sure you want to Add new student", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                SaveStudent();
                Reset(0);

                ID++;
                mtxtID.Text = ID.ToString();
            }
            else
            {

            }
        }

        private void chboxPreferredDays_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!chboxPreferredDays.GetItemChecked(chboxPreferredDays.SelectedIndex))
                AddDays(chboxPreferredDays.SelectedIndex);
            else
                RemoveDays(chboxPreferredDays.SelectedIndex);
        }

        private void cboxArabic_EnabledChanged(object sender, EventArgs e)
        {
            ResetTeacherName((ComboBox)sender);
        }


        private void cboxArabic_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreTeachersName((ComboBox)sender);
        }

        private void listViewAllStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAllStudents.SelectedItems.Count > 0)
            {
                groupBoxTest.Visible = true;
                byte index = Convert.ToByte(listViewAllStudents.SelectedItems[0].SubItems[0].Text);
                lbIDCopy.Text = Convert.ToString(index);
                lbFirstNameCopy.Text = listViewAllStudents.SelectedItems[0].SubItems[1].Text;
                lbMiddleNameCopy.Text = listViewAllStudents.SelectedItems[0].SubItems[2].Text;
                lbLastNameCopy.Text = listViewAllStudents.SelectedItems[0].SubItems[3].Text;
                lbClassCopy.Text = listViewAllStudents.SelectedItems[0].SubItems[4].Text;
                lbGenderCopy.Text = (listViewAllStudents.SelectedItems[0].ImageIndex == 0) ? "Male" : "Female";
                lbSpecializationCopy.Text = listViewAllStudents.SelectedItems[0].SubItems[5].Text;
                lbCoursesCopy.Text = AllStudents[index].CoursesAsText;
                lbPreferredDaysCopy.Text = AllStudents[index].DaysAsText;
                lbTotalCostCopy.Text = Convert.ToString(AllStudents[index].TotalCosts);
            }

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            groupBoxTest.Visible = false;
            treeViewOneStudent.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                treeViewOneStudent.Visible = true;
                treeViewOneStudent.Nodes.Add((TreeNode)treeView2.Nodes[Convert.ToByte(lbIDCopy.Text) - 1].Clone());
            }
            else
            {
                treeViewOneStudent.Nodes.Clear();
                treeViewOneStudent.Visible = false;
            }
        }



        void FillCheckBoxClassesForTeachers(ComboBox ClassesBox)
        {
            chboxClassesTeachers.Items.Clear();
            lbClassesTeachers.Text = "";

            if (ClassesBox.SelectedIndex == 11)
            {
                lbClassesTeachers.Text = "9";
                lbClassesTeachers.Tag = 9;
                lblClassesForTeachers.Visible = false;
                chboxClassesTeachers.Visible = false;
                AddHGDTeacher();
            }
            else
            {
                lblClassesForTeachers.Visible = true;
                chboxClassesTeachers.Visible = true;
                for (int i = 0; i < 4; i++)
                {
                    if ((ClassesBox.SelectedIndex == 9 || ClassesBox.SelectedIndex == 5 || ClassesBox.SelectedIndex == 7) && i == 0)
                        continue;
                    if (i == 2)
                        continue;
                    chboxClassesTeachers.Items.Add(GetClassName((enClass)i));
                    ;
                }
            }
        }

        private void mtxtFirstNameTeacher_TextChanged(object sender, EventArgs e)
        {
            FillTeacherCardLabels((MaskedTextBox)sender);
        }

        void RemoveAddedTeachers()
        {
            while (chboxClassesTeachers.CheckedIndices.Count > 0)
            {
                chboxClassesTeachers.SelectedIndex = chboxClassesTeachers.CheckedIndices[0];
                chboxClassesTeachers.SetItemChecked(chboxClassesTeachers.CheckedIndices[0], false);

            }
        }
        private void cboxCourseTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxCourseTeachers.SelectedItem == null)
                return;
            RemoveAddedTeachers();
            ResetDaysDatesComboBoxes();
            ResetPreferredDaysCheckBoxList(1);
            lbTeacherCourse.Text = cboxCourseTeachers.SelectedItem as string;
            if (cboxCourseTeachers.SelectedIndex >= 0)
                Teacher.Course = (enAllCourses)cboxCourseTeachers.SelectedIndex;
            FillCheckBoxClassesForTeachers((ComboBox)sender);
        }



        private void chboxPreferredDaysTeachers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!chboxPreferredDaysTeachers.GetItemChecked(chboxPreferredDaysTeachers.SelectedIndex))
            {
                UnlockDaysDatesComboBoxes(chboxPreferredDaysTeachers.SelectedIndex);

            }
            else
            {
                LockDaysDatesComboBoxes(chboxPreferredDaysTeachers.SelectedIndex);
            }

        }

        private void rdbMaleTeacher_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbFemaleTeacher.Checked)
            {
                lbGenderTeacher.Text = "Female";
                Teacher.Gender = enGender.Female;
            }
            else
            {
                lbGenderTeacher.Text = "Male";
                Teacher.Gender = enGender.Male;
            }

        }

        private void mtxtSalary_TextChanged(object sender, EventArgs e)
        {
            lbSalary.Text = mtxtSalary.Text;
            if (!string.IsNullOrEmpty(lbSalary.Text))
                Teacher.Salary = Convert.ToInt32(lbSalary.Text);
        }

        private void chboxPreferredDaysTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPreferredDaysLabel((CheckedListBox)sender, 1);
        }

        private void chboxClassesTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbClassesTeachers.Text = "";
            for (int i = 0; i < chboxClassesTeachers.CheckedItems.Count; i++)
            {
                lbClassesTeachers.Text += chboxClassesTeachers.CheckedItems[i].ToString() + ", ";
            }
        }


        private void chboxClassesTeachers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            AddTeachersCount(Teacher.Course, chboxClassesTeachers.SelectedIndex);
        }

        private void btAddTeacher_Click(object sender, EventArgs e)
        {
            if((rdbFemaleTeacher.Checked == false && rdbMaleTeacher.Checked == false)|| mtxtFirstNameTeacher.Text == null || mtxtMiddleNameTeacher.Text == null
                || mtxtLastNameTeacher.Text == null || mtxtSalary.Text == null|| cboxCourseTeachers.SelectedItem == null)
            {
                MessageBox.Show("Please Fill All required fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add new Teacher?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveTeacher();
                Reset(1);
                FillTreeViewCoursesTeachersClasses();
            }
            else
            {

            }
        }

        private void btResetStudent_Click(object sender, EventArgs e)
        {
            Reset(0);
        }

        private void listViewAllTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAllTeachers.SelectedItems.Count > 0)
            {
                groupBoxCopyTeacher.Visible = true;
                byte ID = Convert.ToByte(listViewAllTeachers.SelectedItems[0].SubItems[0].Text);
                lbCopyTeacherID.Text = Convert.ToString(ID);
                lbCopyTeacherFirstName.Text = listViewAllTeachers.SelectedItems[0].SubItems[1].Text;
                lbCopyTeacherMiddleName.Text = listViewAllTeachers.SelectedItems[0].SubItems[2].Text;
                lbCopyTeacherLastName.Text = listViewAllTeachers.SelectedItems[0].SubItems[3].Text;
                lbCopyTeacherGender.Text = (listViewAllTeachers.SelectedItems[0].ImageIndex == 1) ? "Female" : "Male";
                lbCopyTeacherClass.Text = listViewAllTeachers.SelectedItems[0].SubItems[5].Text;
                lbCopyTeacherCourse.Text = listViewAllTeachers.SelectedItems[0].SubItems[4].Text;
                lbCopyTeacherSalary.Text = listViewAllTeachers.SelectedItems[0].SubItems[6].Text;
                lbCopyTeacherPreferredDays.Text = listViewAllTeachers.SelectedItems[0].SubItems[7].Text;
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox1.Tag = "Teacher";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox1.Tag = "Student";
            }
        }

        void RecordPayment(string Name, string value)
        {
            if (comboBox1.Tag == "Teacher")
            {
                ListViewItem record = new ListViewItem(Convert.ToString(DateTime.Now));
                string description = Name + " was payed " + value;
                record.SubItems.Add(description);
                listViewPaymentRecord.Items.Add(record);
            }
            if (comboBox1.Tag == "Student")
            {
                ListViewItem record = new ListViewItem(Convert.ToString(DateTime.Now));
                string description = Name + " payed " + value;
                record.SubItems.Add(description);
                listViewPaymentRecord.Items.Add(record);
            }
        }
        void ResetPayment()
        {

            comboBox1.SelectedItem = null;
            mtxtIDPayment.Text = "";
            mtxtPaymentValue.Text = "";
        }
        private void btConfirmPayment_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || mtxtIDPayment.Text == null || mtxtPaymentValue.Text == null)
            {
                MessageBox.Show("Please Fill All required fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.Tag == "Teacher")
            {
                if(listViewAllTeachers.Items.Count == 0 || Convert.ToByte(mtxtIDPayment.Text) > listViewAllTeachers.Items.Count ||
                   Convert.ToByte(mtxtIDPayment.Text) <= 0)
                {
                    MessageBox.Show("Please Add Teachers First", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Name = AllTeachers[Convert.ToByte(mtxtIDPayment.Text)].FirstName + " " + AllTeachers[Convert.ToByte(mtxtIDPayment.Text)].LastName;
                if (MessageBox.Show("Are You sure you want to pay " + Name + " " + mtxtPaymentValue.Text, "", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AllTeachers[Convert.ToByte(mtxtIDPayment.Text)].RemainedSalary =
                        AllTeachers[Convert.ToByte(mtxtIDPayment.Text)].RemainedSalary - Convert.ToInt32(mtxtPaymentValue.Text);
                    listViewAllTeachers.Items[Convert.ToByte(mtxtIDPayment.Text) - 1].SubItems[8].Text =
                        Convert.ToString(AllTeachers[Convert.ToByte(mtxtIDPayment.Text)].RemainedSalary);
                    if (AllTeachers[Convert.ToByte(mtxtIDPayment.Text)].RemainedSalary == 0)
                    {
                        listViewAllTeachers.Items[Convert.ToByte(mtxtIDPayment.Text) - 1].ForeColor = Color.Green;
                    }
                    RecordPayment(Name, mtxtPaymentValue.Text);
                    ResetPayment();
                }
                else
                {
                    ResetPayment();
                }
            }
            if (comboBox1.Tag == "Student")
            {
                if (listViewAllStudents.Items.Count == 0 || Convert.ToByte(mtxtIDPayment.Text) > listViewAllStudents.Items.Count ||
                   Convert.ToByte(mtxtIDPayment.Text) <= 0)
                {
                    MessageBox.Show("Please Add Students First", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Name = AllStudents[Convert.ToByte(mtxtIDPayment.Text)].FirstName + " " + AllStudents[Convert.ToByte(mtxtIDPayment.Text)].LastName;
                if (MessageBox.Show($"Are You sure you want to receive from " + Name + " " + mtxtPaymentValue.Text, "", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AllStudents[Convert.ToByte(mtxtIDPayment.Text)].RemainedCosts =
                    AllStudents[Convert.ToByte(mtxtIDPayment.Text)].RemainedCosts - Convert.ToInt32(mtxtPaymentValue.Text);
                    listViewAllStudents.Items[Convert.ToByte(mtxtIDPayment.Text) - 1].SubItems[9].Text =
                        Convert.ToString(AllStudents[Convert.ToByte(mtxtIDPayment.Text)].RemainedCosts);
                    if (AllStudents[Convert.ToByte(mtxtIDPayment.Text)].RemainedCosts == 0)
                    {
                        listViewAllStudents.Items[Convert.ToByte(mtxtIDPayment.Text) - 1].ForeColor = Color.Green;
                    }

                    RecordPayment(Name, mtxtPaymentValue.Text);
                    ResetPayment();

                }

                else
                {

                    ResetPayment();
                }
            }
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {
            groupBoxCopyTeacher.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset(1);
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage2;
            tabControl2.SelectedTab = tabPageAddStudent;
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            tabControl3.SelectedTab = tabPageAddTeacher;
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage2;
            tabControl2.SelectedTab = tabPageViewStudents;

        }

        private void studentsCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            tabControl2.SelectedTab = tabPageShowCoursesStudents;
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            tabControl3.SelectedTab = tabPageViewTeachers;
        }

        private void teachersCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            tabControl3.SelectedTab = tabPageViewTeachers;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void cboxClassesMainScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxCoursesMainScreen.Items.Clear();
            if (cboxClassesMainScreen.SelectedIndex == 0)
            {

                for (int i = 2; i <= 512; i *= 2)
                {

                    cboxCoursesMainScreen.Items.Add(Get9CourseName((en9ClassCourses)i));

                }
            }
            else
            {
                for (int i = 2; i <= 256; i *= 2)
                {

                    cboxCoursesMainScreen.Items.Add(GetScientificCourseName((enScientificCourses)i));

                }

                for (int i = 16; i <= 64; i *= 2)
                {

                    cboxCoursesMainScreen.Items.Add(GetLiteratureCourseName((enLiteratureCourses)i));

                }

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cboxClassesMainScreen.SelectedItem == null || cboxCoursesMainScreen.SelectedItem == null
                || mtxtboxRoomNo.Text == null)
            {
                MessageBox.Show("Please Fill All required fields","", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add a course date on " +  DateTimePicker.Text.ToString() +
                "  ? ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.OK)
            {
                ListViewItem CourseDate = new ListViewItem(cboxClassesMainScreen.SelectedItem.ToString());
                CourseDate.SubItems.Add(cboxCoursesMainScreen.SelectedItem.ToString().Trim());
                DateTime @Date = DateTimePicker.Value;
                CourseDate.Tag = @Date;
                CourseDate.SubItems.Add(Date.ToString());
                CourseDate.SubItems.Add(mtxtboxRoomNo.Text.ToString());
                CourseDate.SubItems.Add("");
                listView1.Items.Add(CourseDate);
                cboxClassesMainScreen.SelectedItem = null;
                cboxCoursesMainScreen.SelectedItem = null;
                mtxtboxRoomNo.Text = null;
                DateTimePicker.Text = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cboxClassesMainScreen.SelectedItem = null;
            cboxCoursesMainScreen.SelectedItem = null;
            mtxtboxRoomNo.Text = null;
            DateTimePicker.Text = null;
        }





        private void timer2_Tick(object sender, EventArgs e)
        {
            byte OngoingCourses = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                
                if (listView1.Items[i].Tag is DateTime itemDateTime)
                {
                    if ((itemDateTime <= DateTime.Now) && ((DateTime.Now - itemDateTime).Duration() <= TimeSpan.FromHours(1.5)))
                    {
                        OngoingCourses++;
                        listView1.Items[i].ForeColor = Color.Blue;
                        listView1.Items[i].SubItems[4].Text = "Ongoing";
                       
                    }

                    if ((itemDateTime <= DateTime.Now) && ((DateTime.Now - itemDateTime).Duration() > TimeSpan.FromHours(1.5)))
                    {

                        listView1.Items[i].ForeColor = Color.Green;
                        listView1.Items[i].SubItems[4].Text = "Done";
                      
                    }

                    if ((itemDateTime > DateTime.Now))
                    {
                        OngoingCourses++;
                        listView1.Items[i].ForeColor = Color.Red;
                        listView1.Items[i].SubItems[4].Text = "Undone";

                    }

                }
            }
        }

    private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

            listViewAllStudents.SelectedItems[0].Remove();

        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            listViewAllTeachers.SelectedItems[0].Remove();
        }
    }
}
