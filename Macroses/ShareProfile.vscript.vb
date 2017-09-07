'#include(lib_utils)
'#include(lib_dialog_2)
'#include(lib_client)

abi = "[{""inputs"": [], ""constant"": true, ""name"": ""guid"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""uint16"", ""name"": ""_year""}, {""type"": ""uint8"", ""name"": ""_month""}, {""type"": ""uint8"", ""name"": ""_day""}], ""constant"": false, ""name"": ""setBirthday"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_email""}], ""constant"": false, ""name"": ""setEmail"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""getAccess"", ""outputs"": [{""type"": ""bool"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_firstName""}], ""constant"": false, ""name"": ""setFirstName"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getLastName"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""revokeAccess"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getEmail"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""grantAccess"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getPhone"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": true, ""name"": ""owner"", ""outputs"": [{""type"": ""address"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_lastName""}], ""constant"": false, ""name"": ""setLastName"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getFirstName"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getBirthday"", ""outputs"": [{""type"": ""uint16"", ""name"": ""year""}, {""type"": ""uint8"", ""name"": ""month""}, {""type"": ""uint8"", ""name"": ""day""}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_phone""}], ""constant"": false, ""name"": ""setPhone"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_guid""}, {""type"": ""string"", ""name"": ""_firstName""}, {""type"": ""string"", ""name"": ""_lastName""}, {""type"": ""string"", ""name"": ""_email""}, {""type"": ""string"", ""name"": ""_phone""}, {""type"": ""uint16"", ""name"": ""_birthYear""}, {""type"": ""uint8"", ""name"": ""_birthMonth""}, {""type"": ""uint8"", ""name"": ""_birthDay""}], ""type"": ""constructor"", ""payable"": false}]"

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
MyForms.Screen("Start").Title = "Share profile"
MyForms.Screen("Start").addComponent("caption", "text")
MyForms.Screen("Start").Component("caption").value("Enter recipient email address and account")
MyForms.Screen("Start").addComponent("toemail","livesearch")
MyForms.Screen("Start").Component("toemail").label("Recipient e-mail :")
MyForms.Screen("Start").Component("toemail").sourceURI("/recipientlivesearch")
MyForms.Screen("Start").addComponent("account","TextBox")
MyForms.Screen("Start").Component("account").label("Recipient account :")
opt = dictionary
opt("firstName") = "Read First name"
opt("lastName") = "Read Last name"
opt("email") = "Read Email"
opt("phone") = "Read Phone"
opt("birthday") = "Read Birthday"
MyForms.Screen("Start").addComponent("permissions", "CheckBox")
MyForms.Screen("Start").Component("permissions").label("Set allowed access :")
MyForms.Screen("Start").Component("permissions").setOptions(opt)
MyForms.Screen("Start").Component("permissions").breakline("true")
MyForms.Screen("Start").addComponent("btns", "btngroup")
MyForms.Screen("Start").Component("btns").addBtn("Share", "Share")

MyForms.addScreen("Done")
MyForms.Screen("Done").width  = 600
MyForms.Screen("Done").Height = 400
MyForms.Screen("Done").Title = "Share profile"
MyForms.Screen("Done").addComponent("caption", "text")
MyForms.Screen("Done").Component("caption").value("Email sent")
MyForms.Screen("Done").addComponent("timeout","Timer")
MyForms.Screen("Done").Component("timeout").setTimer("Exit", 1000)
MyForms.Screen("Done").addComponent("btns", "btngroup")
MyForms.Screen("Done").Component("btns").addBtn("OK", "End")

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

function share_profile(e, mailbox)
    vdomxml = "<CONTAINER name=""container1"" designcolor=""84A2F0"" top=""9"" height=""443"" width=""561"" left=""18"">"&_
               "  <RICHTEXT name=""richtext2"" top=""75"" left=""37""/>"&_
               "    <TEXT name=""text1"" top=""23"" value=""Loading"" width=""185"" fontsize=""20"" left=""125""/>"&_
               "</CONTAINER>"
    myguid = generateguid()        
    e.dynamic = true
    e.auth = "internal"
    e.session_token = ""
    e.login_container = "5073ff75-da99-44fb-a5d7-e44e5ab28598"
    e.login_method = "login"
    e.get_container = "5073ff75-da99-44fb-a5d7-e44e5ab28598"
    e.get_method = "call_macro"
    e.get_data = "{""plugin_guid"": ""6787f2ab-39ff-4dbc-9d1a-04a6ee684857"", ""async"": 0, ""data"": {""contract"": """ + contract_id +"""}, ""name"": ""loaddata""}"
    e.api_server = "localhost"
    e.app_id = "7f459762-e1ba-42d3-a0e1-e74beda2eb85"
    e.vdomxml_data = vdomxml
    e.eac_token = myguid
    e.eac_method = "update"
    'logger e.get_wholexml()

    Appinmail.acl.registerEac(myguid)
    toEmails = Appinmail.utils.parseEmails(args)
    Appinmail.acl.add(myguid, toEmails, "r")
    users = Appinmail.users.resolve(toEmails)
    for each user in users
        try
            e.send(mailbox, user("login"), "", "", user("short_login") & " Identity profile", "")
        catch
        end try
    next
end function

Select case mainStep

  case "Start"
    if contract_id = "" then
      MyForms.ShowScreen("NoProfile")
    else
      MyForms.ShowScreen("Start")
    end if

  case "Share"
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

    Set e = new EAC 
    share_profile(e, ProMail.selected_mailbox)
    MyForms.ShowScreen("Done")

end select