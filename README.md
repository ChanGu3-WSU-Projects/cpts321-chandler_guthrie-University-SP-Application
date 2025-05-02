# Final-Exam
## Name : Chandler Guthrie
## WSUID: 011801740

## Link To Application Demo
# https://emailwsu-my.sharepoint.com/:v:/g/personal/chandler_guthrie_wsu_edu/EVQDzJgyyAhCi-o3YhfWOIABhxLFXO9-0EkjwiIvGOHnLQ

## Features Implemented
### Features For Guests
1. View the list of all projects for which clubs are raising money. 
2. View details of a specific club project for which clubs are raising money.
3. View scholarships.
4. View details of a specific scholarship.
5. Register/create an account.
6. Login.

### Features For Students
12. Update the list of clubs that they are members of.
13. Register a club project.
14. Apply for a scholarship.
15. View history of scholarship applications that the student has applied to or has been awarded.
16. View history of club projects that the student has participated in.

## Features Missing

### Features For Donors
7. Make a donation for a registered club project:
8. View history of donations
9. Setup a scholarship
10. View status of a scholarship
11. Review applications and provide recommendations for scholarships






## Style Cop Removals
### SA1401(All fields must be private): 
- Removed due to requirements of field being an protected access modifier.

### SA1009(Closing parenthesis should be spaced correctly): 
- Formatting Of Code Prevents specific case with null forgiving operator. I check for null before using this operator.
- Ex. 
- Required: this.spreadsheet.GetCell(1, 1) !.Text
- Formatter: this.spreadsheet.GetCell(1, 1)!.Text
- checked for hours to fix this with no solution

### SA1009(A closing square bracket within a C# statement is not spaced correctly): 
- Formatting of code prevents space with a nullable array.
- Ex. 
- Required: private object[] ? cellReferences = null;
- Formatter: private object[]? cellReferences = null;