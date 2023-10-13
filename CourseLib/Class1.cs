using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// INITIAL COURSES CODE FROM IN-CLASS EXAMPLE

namespace CourseLib
{

    /* Class: Courses
     * Author: Katie Bogart
     * Purpose: store and modify a sorted list of courses
     * Restrictions: None
     */
    public class Courses
    {
        SortedList<string, Course> sortedList = new SortedList<string, Course>();

        /* Method: Remove
         * Purpose: if a course is in the list, remove it
         * Restrictions: None
         */
        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode);
            }
        }

        /* Method: Course
         * Purpose: get
         *          checks if a Course with a certain code exists
         *          if it does, return the course
         *          
         *          set
         *          tries to add a course with a certain course code
         *          if it already exists, 
         * Restrictions: None
         */
        public Course this[string courseCode]
        {
            get
            {
                Course returnVal;
                try
                {
                    returnVal = (Course)sortedList[courseCode];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    sortedList[courseCode] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling (currently ignoring any exceptions)
                }
            }
        }

        /* Method: Courses
         * Purpose: creates a list of 100 courses
         * Restrictions: None
         */
        public Courses()
        {
            Course thisCourse;
            Schedule thisSchedule;

            Random rand = new Random();

            // generate courses IGME-200 through IGME-299
            for (int i = 200; i < 300; ++i)
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i}"), ($"Description for IGME-{i}"));

                // create a new Schedule object
                thisSchedule = new Schedule();
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);
                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule;

                // add this course to the SortedList
                this[thisCourse.courseCode] = thisCourse;
            }
        }

    }

    /* Class: Course
     * Author: Katie Bogart
     * Purpose: create a course with a given code and description
     * Restrictions: None
     */
    public class Course
    {
        // initialize fields
        public string courseCode;
        public string description;
        public string teacherEmail;
        public Schedule schedule;

        /* Method: Course
         * Purpose: creates a course with default values
         * Restrictions: None
         */
        public Course()
        {
            this.courseCode = null;
            this.description = null;
            this.teacherEmail = null;
            this.schedule = null;
        }

        /* Method: Course
         * Purpose: creates a course with given code and description
         * Restrictions: None
         */
        public Course(string courseCode, string description)
        {
            this.courseCode = courseCode;
            this.description = description;
            this.teacherEmail = null;
            this.schedule = null;
        }
    }

    /* Class: Schedule
     * Author: Katie Bogart
     * Purpose: create a schedule
     * Restrictions: None
     */
    public class Schedule
    {
        public DateTime startTime;
        public DateTime endTime;
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();
    }
}
