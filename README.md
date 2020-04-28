# Student-Booking-App-With-Faculty-Advisors
This is a web application that helps students in booking appointment with their faculty advisors.

The application is based on ASP.Net MVC4, Entity Framework 6.0 (using code-first approach) and MS SQL Server.
On the front-end Bootstrap 4.0, Jquery 2.0 and Jquery-UI 1.12 is used.

This application allows a new user to register as a Faculty or a Student.
The application maintains three user roles namely Admin, Faculty and Student.

Admin:
The admin can enable or disable the 'Update Schedule' functionality for a faculty.

Faculty:
Faculties can update their schedule for each day of the week(Monday-Saturday). Also, faculties can check their existing appointments
with the students.

Student:
A student can make appointment with a faculty on a day based on the faculty's schedule and available appointment slots on that day.
If all apppintment slots are taken, then, the student can add his appointment on waitlist. If an appointment slot gets avaialble then 
all the waitlisted students and the sutdents having appointment later on that day get notified through email.
A student can also check his/her exising appointments.
