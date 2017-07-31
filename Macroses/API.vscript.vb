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

account_id = read_account()

set myclient = new web3client
myclient.host = client_host
myclient.port = client_port
if account_id <> "" then
  myclient.account = account_id
  myclient.unlock_account(client_password)
end if

args = event.data
contract = args("additional")("contract")

function read_profile(client, contract_id)
  d = new dictionary
  d("firstName") = client.contract_call(abi, contract_id, "getFirstName")
  d("lastName") = client.contract_call(abi, contract_id, "getLastName")
  d("email") = client.contract_call(abi, contract_id, "getEmail")
  d("phone") = client.contract_call(abi, contract_id, "getPhone")
  birthday = client.contract_call(abi, contract_id, "getBirthday")
  d("birthday") = birthday(2) & "." & birthday(1) & "." & birthday(0)
  read_profile = d
end function

function get_profile
    set EACAnswer = buffer.create

    p = read_profile(myclient, contract)
    htmldata = "First name: " & p("firstName") & "<br>Last name: " & p("lastName") & "<br>E-mail: " & p("email") & "<br>Phone: " & p("phone") & "<br>Birthday: " & p("birthday")

    EACAnswer.write("  <WHOLEXML Content=""dynamic"" SessionToken="""" Auth=""internal"">")
    EACAnswer.write ("<EVENTS>")
    EACAnswer.write ("</EVENTS>")
    EACAnswer.write (" <VDOMXML>")
    EACAnswer.write (" <![CDATA[")
    EACAnswer.write ("<CONTAINER name=""container1"" backgroundcolor=""DFDBE8"" designcolor=""84A2F0"" top=""0"" height=""500"" width=""600"" left=""0"">")
    EACAnswer.write ("    <RICHTEXT name=""richtext2"" top=""20"" left=""200"" value=""Identity profile data""/>")
    EACAnswer.write ("    <HYPERTEXT name=""text1"" left=""15"" top=""50"" width=""500"" height=""400"">")
    EACAnswer.write ("        <Attribute Name=""htmlcode"">")
    EACAnswer.write ("            <![CDATA[" & htmldata & "<br><br><br>]]]]><![CDATA[>")
    EACAnswer.write ("        </Attribute>")
    EACAnswer.write ("    </HYPERTEXT>")
    EACAnswer.write ("</CONTAINER>")
    EACAnswer.write (" ]]>")
    EACAnswer.write (" </VDOMXML>")
    EACAnswer.write ("</WHOLEXML>")
    logger (EACAnswer.getValue)
    
    get_profile = EACAnswer.getValue()
end function

result = get_profile()
response.write(result)