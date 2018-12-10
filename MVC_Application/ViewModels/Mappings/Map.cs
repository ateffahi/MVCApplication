using MVC_Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Application.ViewModels.Mappings
{
    public static class Map
    {

        #region Mapping Student to StudentViewmodel
        public static StudentViewModel MapToStudentViewmodel(this Student student)
        {
            var studentVM = new StudentViewModel();

            if (student == null)
            {
                return studentVM;
            }

            studentVM.Id = student.Id;
            studentVM.Name = student.Name;

            #region comment
            // on peut utiliser cette notation 
            //studentVM = new StudentViewModel()
            //{
            //    Id = student.Id,
            //    Name = student.Name
            //};
            #endregion

            return studentVM;
        }

        #endregion

        #region Mapping StudentViewmodel to Student
        public static Student MapToStudent(this StudentViewModel studentVM)
        {
            var student = new Student();

            if (studentVM == null)
            {
                return student;
            }

            student.Id = studentVM.Id;
            student.Name = studentVM.Name;

            #region comment
            // on peut utiliser cette notation 
            //student = new Student()
            //{
            //    Id = studentVM.Id,
            //    Name = studentVM.Name
            //};
            #endregion

            return student;
        }
        #endregion

        #region Mapping Attendance to StudentAttendanceViewModel
        public static StudentAttendanceViewModel MapToStudentAttendanceViewModel(this Attendance attendance)
        {
            var studentAttendanceVM = new StudentAttendanceViewModel();

            if (attendance == null)
            {
                return studentAttendanceVM;
            }

            studentAttendanceVM = new StudentAttendanceViewModel()
            {
                Id = attendance.Id,
                Date = attendance.Date,
                IsPresent = attendance.IsPresent,
                Student = attendance.Student.MapToStudentViewmodel(), // Student can call MaptoStudentviewmodel because of "this student" : méthode d'extension.
                //Student = MapToStudentViewmodel(attendance.Student), // We can do it too !! 
                IdClassRoom = attendance.IdClassRoom,
                ClassRoomName = attendance.ClassRoom.Name
            };

            return studentAttendanceVM;
        }
        #endregion

        #region Mapping StudentAttendanceViewModel to Attendance
        public static Attendance MapToAttendance(this StudentAttendanceViewModel studentAttendanceVM)
        {
            var Attendance = new Attendance();

            if (studentAttendanceVM == null)
            {
                return Attendance;
            }

            Attendance = new Attendance()
            {

                Id = studentAttendanceVM.Id,
                Date = studentAttendanceVM.Date,
                IsPresent = studentAttendanceVM.IsPresent,
                IdStudent = studentAttendanceVM.Student.Id,
                IdClassRoom = studentAttendanceVM.IdClassRoom,
            };
            return Attendance;
        }
        #endregion


    }
}
