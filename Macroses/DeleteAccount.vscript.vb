'#include(lib_utils)
'#include(lib_dialog_2)

args = xml_dialog.get_answer

if "step" in args then
  if args( "step" )<>"" then
    operation_step = args( "step" )
  end if
else
  operation_step =""
end if

if operation_step = "" then
  operation_step = "Start"
end if

set MyForms = New XMLDialogBuilder

MyForms.addScreen("Start")
MyForms.Screen("Start").width  = 600
MyForms.Screen("Start").Height = 400
MyForms.Screen("Start").Title = "Delete account"
MyForms.Screen("Start").addComponent("caption", "text")
MyForms.Screen("Start").Component("caption").value("Do you really want to delete your account?")
MyForms.Screen("Start").addComponent("btns", "btngroup")
MyForms.Screen("Start").Component("btns").addBtn("Yes", "Yes")
MyForms.Screen("Start").Component("btns").addBtn("No", "No")
MyForms.addScreen("Deleted")
MyForms.Screen("Deleted").width  = 600
MyForms.Screen("Deleted").Height = 400
MyForms.Screen("Deleted").Title = "Delete account"
MyForms.Screen("Deleted").addComponent("caption", "text")
MyForms.Screen("Deleted").Component("caption").value("Your account was deleted")
MyForms.Screen("Deleted").addComponent("timeout","Timer")
MyForms.Screen("Deleted").Component("timeout").setTimer("Exit", 1000)
MyForms.Screen("Deleted").addComponent("btns", "btngroup")
MyForms.Screen("Deleted").Component("btns").addBtn("OK", "End")

if instr(operation_step,">")<>0 then
  mainStep = split(operation_step,">")(0)
  subStep = split(operation_step,">")(1)
else
  mainStep = operation_step
  subStep = ""
end if

Select case mainStep

  case "Start"
    MyForms.ShowScreen("Start")
    
  case "Yes"
    try
      tempresources.delete("account")
    catch
    end try
    try
      tempresources.delete("contract")
    catch
    end try
    try
      tempresources.delete("transaction")
    catch
    end try
    MyForms.ShowScreen("Deleted")

end select