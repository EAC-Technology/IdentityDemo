'#include(lib_utils)
'#include(lib_dialog_2)

abi = "[{""inputs"": [], ""constant"": true, ""name"": ""guid"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""uint16"", ""name"": ""_year""}, {""type"": ""uint8"", ""name"": ""_month""}, {""type"": ""uint8"", ""name"": ""_day""}], ""constant"": false, ""name"": ""setBirthday"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_email""}], ""constant"": false, ""name"": ""setEmail"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""getAccess"", ""outputs"": [{""type"": ""bool"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_firstName""}], ""constant"": false, ""name"": ""setFirstName"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getLastName"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""revokeAccess"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getEmail"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""grantAccess"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getPhone"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": true, ""name"": ""owner"", ""outputs"": [{""type"": ""address"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_lastName""}], ""constant"": false, ""name"": ""setLastName"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getFirstName"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getBirthday"", ""outputs"": [{""type"": ""uint16"", ""name"": ""year""}, {""type"": ""uint8"", ""name"": ""month""}, {""type"": ""uint8"", ""name"": ""day""}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_phone""}], ""constant"": false, ""name"": ""setPhone"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_guid""}, {""type"": ""string"", ""name"": ""_firstName""}, {""type"": ""string"", ""name"": ""_lastName""}, {""type"": ""string"", ""name"": ""_email""}, {""type"": ""string"", ""name"": ""_phone""}, {""type"": ""uint16"", ""name"": ""_birthYear""}, {""type"": ""uint8"", ""name"": ""_birthMonth""}, {""type"": ""uint8"", ""name"": ""_birthDay""}], ""type"": ""constructor"", ""payable"": false}]"

client_host = "10.41.0.16"
client_port = 8545
client_password = "password"

FIRST_NAME = 0
LAST_NAME = 1
EMAIL = 2
PHONE = 3
BIRTHDAY = 4

function read_account
  try
    read_account = tempresources.open("account").read()
    logger "Account " & read_account
  catch
    read_account = ""
  end try
end function

function read_contract
try
    read_contract = tempresources.open("contract").read()
    logger "Contract " & read_contract
  catch
    read_contract = ""
  end try
end function

account_id = read_account()
contract_id = read_contract()

set myclient = new web3client
myclient.host = client_host
myclient.port = client_port
if account_id <> "" then
  myclient.account = account_id
  myclient.unlock_account(client_password)
end if

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

MyForms.addScreen("NoProfile")
MyForms.Screen("NoProfile").width  = 600
MyForms.Screen("NoProfile").Height = 400
MyForms.Screen("NoProfile").Title = "Share profile"
MyForms.Screen("NoProfile").addComponent("caption", "text")
MyForms.Screen("NoProfile").Component("caption").value("You don't have an Identity profile yet. Run MyProfile macro to create it.")
MyForms.Screen("NoProfile").addComponent("btns", "btngroup")
MyForms.Screen("NoProfile").Component("btns").addBtn("OK", "End")

MyForms.addScreen("Start")
MyForms.Screen("Start").width  = 600
MyForms.Screen("Start").Height = 400
MyForms.Screen("Start").Title = "Permissions"
MyForms.Screen("Start").addComponent("caption", "text")
MyForms.Screen("Start").Component("caption").value("View/Edit permissions of other users to be able to view your account")
MyForms.Screen("Start").addComponent("account", "TextBox")
MyForms.Screen("Start").Component("account").label("Other user account :")
MyForms.Screen("Start").addComponent("btns", "btngroup")
MyForms.Screen("Start").Component("btns").addBtn("Load", "Load")

if instr(operation_step,">")<>0 then
  mainStep = split(operation_step,">")(0)
  subStep = split(operation_step,">")(1)
else
  mainStep = operation_step
  subStep = ""
end if

function load_permissions(account)
    d = new dictionary
    param = Array
    Redim param(1)
    param(0) = account
    param(1) = FIRST_NAME
    d("firstName") = myclient.contract_call(abi, contract_id, "getAccess", param)
    param(1) = LAST_NAME
    d("lastName") = myclient.contract_call(abi, contract_id, "getAccess", param)
    param(1) = EMAIL
    d("email") = myclient.contract_call(abi, contract_id, "getAccess", param)
    param(1) = PHONE
    d("phone") = myclient.contract_call(abi, contract_id, "getAccess", param)
    param(1) = BIRTHDAY
    d("birthday") = myclient.contract_call(abi, contract_id, "getAccess", param)
    load_permissions = d
end function

function show_load_screen
    another_account = args("account")

    p = load_permissions(another_account)

    MyForms.addScreen("Load")
    MyForms.Screen("Load").width  = 600
    MyForms.Screen("Load").Height = 400
    MyForms.Screen("Load").Title = "Permissions"
    MyForms.Screen("Load").addComponent("caption", "text")
    MyForms.Screen("Load").Component("caption").value("View/Edit permissions of other users to be able to view your account")
    MyForms.Screen("Load").addComponent("account", "TextBox")
    MyForms.Screen("Load").Component("account").label("Other user account :")
    MyForms.Screen("Load").Component("account").defaultValue(another_account)

    opt = dictionary
    opt("firstName") = "Read First name"
    opt("lastName") = "Read Last name"
    opt("email") = "Read Email"
    opt("phone") = "Read Phone"
    opt("birthday") = "Read Birthday"
    selected = ""
    if p("firstName") then
      if selected <> "" then
        selected = selected & ","
      end if
      selected = selected & "firstName"
    end if
    if p("lastName") then
      if selected <> "" then
        selected = selected & ","
      end if
      selected = selected & "lastName"
    end if
    if p("email") then
      if selected <> "" then
        selected = selected & ","
      end if
      selected = selected & "email"
    end if
    if p("phone") then
      if selected <> "" then
        selected = selected & ","
      end if
      selected = selected & "phone"
    end if
    if p("birthday") then
      if selected <> "" then
        selected = selected & ","
      end if
      selected = selected & "birthday"
    end if

    MyForms.Screen("Load").addComponent("permissions", "CheckBox")
    MyForms.Screen("Load").Component("permissions").label("Current permissions :")
    MyForms.Screen("Load").Component("permissions").setOptions(opt)
    if selected <> "" then
      MyForms.Screen("Load").Component("permissions").setSelected(selected)
    end if
    MyForms.Screen("Load").Component("permissions").breakline("true")
    MyForms.Screen("Load").addComponent("btns", "btngroup")
    MyForms.Screen("Load").Component("btns").addBtn("Save", "Save")
    MyForms.Screen("Load").Component("btns").addBtn("Load", "Load")

    MyForms.ShowScreen("Load")
end function

function set_permission(param, id, currentValue, newValue)
    param(1) = id
    if currentValue <> newValue then
      if newValue then
        myclient.contract_call(abi, contract_id, "grantAccess", param, 0, true)
      else
        myclient.contract_call(abi, contract_id, "revokeAccess", param, 0, true)
      end if
    end if
end function

Select case mainStep

  case "Start"
    if contract_id = "" then
      MyForms.ShowScreen("NoProfile")
    else
      MyForms.ShowScreen("Start")
    end if

  case "Load"
    show_load_screen()

  case "Save"
    another_account = args("account")

    p = load_permissions(another_account)

    bFirstName = false
    if args("permissions[firstName]") = "on" then
      bFirstName = true
    end if
    bLastName = false
    if args("permissions[lastName]") = "on" then
      bLastName = true
    end if
    bEmail = false
    if args("permissions[email]") = "on" then
      bEmail = true
    end if
    bPhone = false
    if args("permissions[phone]") = "on" then
      bPhone = true
    end if
    bBirthday = false
    if args("permissions[birthday]") = "on" then
      bBirthday = true
    end if

    param = Array
    Redim param(1)
    param(0) = another_account

    set_permission(param, FIRST_NAME, p("firstName"), bFirstName)
    set_permission(param, LAST_NAME, p("lastName"), bLastName)
    set_permission(param, EMAIL, p("email"), bEmail)
    set_permission(param, PHONE, p("phone"), bPhone)
    set_permission(param, BIRTHDAY, p("birthday"), bBirthday)

    show_load_screen()

end select