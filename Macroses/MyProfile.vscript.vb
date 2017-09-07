'#include(lib_utils)
'#include(lib_dialog_2)
'#include(lib_client)

abi = "[{""inputs"": [], ""constant"": true, ""name"": ""guid"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""uint16"", ""name"": ""_year""}, {""type"": ""uint8"", ""name"": ""_month""}, {""type"": ""uint8"", ""name"": ""_day""}], ""constant"": false, ""name"": ""setBirthday"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_email""}], ""constant"": false, ""name"": ""setEmail"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""getAccess"", ""outputs"": [{""type"": ""bool"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_firstName""}], ""constant"": false, ""name"": ""setFirstName"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getLastName"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""revokeAccess"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getEmail"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""address"", ""name"": ""addr""}, {""type"": ""uint8"", ""name"": ""field""}], ""constant"": false, ""name"": ""grantAccess"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getPhone"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": true, ""name"": ""owner"", ""outputs"": [{""type"": ""address"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_lastName""}], ""constant"": false, ""name"": ""setLastName"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getFirstName"", ""outputs"": [{""type"": ""string"", ""name"": """"}], ""payable"": false, ""type"": ""function""}, {""inputs"": [], ""constant"": false, ""name"": ""getBirthday"", ""outputs"": [{""type"": ""uint16"", ""name"": ""year""}, {""type"": ""uint8"", ""name"": ""month""}, {""type"": ""uint8"", ""name"": ""day""}], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_phone""}], ""constant"": false, ""name"": ""setPhone"", ""outputs"": [], ""payable"": false, ""type"": ""function""}, {""inputs"": [{""type"": ""string"", ""name"": ""_guid""}, {""type"": ""string"", ""name"": ""_firstName""}, {""type"": ""string"", ""name"": ""_lastName""}, {""type"": ""string"", ""name"": ""_email""}, {""type"": ""string"", ""name"": ""_phone""}, {""type"": ""uint16"", ""name"": ""_birthYear""}, {""type"": ""uint8"", ""name"": ""_birthMonth""}, {""type"": ""uint8"", ""name"": ""_birthDay""}], ""type"": ""constructor"", ""payable"": false}]"
code = "606060405234156200001057600080fd5b6040516200140f3803806200140f833981016040528080518201919060200180518201919060200180518201919060200180518201919060200180518201919060200180519060200190919080519060200190919080519060200190919050505b336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055508760019080519060200190620000c9929190620001fd565b508660029080519060200190620000e2929190620001fd565b508560039080519060200190620000fb929190620001fd565b50846004908051906020019062000114929190620001fd565b5083600590805190602001906200012d929190620001fd565b5082600660006101000a81548161ffff021916908361ffff16021790555081600660026101000a81548160ff021916908360ff16021790555080600660036101000a81548160ff021916908360ff16021790555060ff600760007313a45970e91b8845eadd8f539ae8822f0bbd611773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff021916908360ff1602179055505b5050505050505050620002ac565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200024057805160ff191683800117855562000271565b8280016001018555821562000271579182015b828111156200027057825182559160200191906001019062000253565b5b50905062000280919062000284565b5090565b620002a991905b80821115620002a55760008160009055506001016200028b565b5090565b90565b61115380620002bc6000396000f300606060405236156100d9576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630ae6d46b146100de5780630e082b101461016d578063282b065a146101ac5780636305bd5b146102095780636392f76b146102665780636b109282146102c35780636f925535146103525780637e79e8ba1461039757806387ed1bd0146104265780638863bab01461046b5780638da5cb5b146104fa578063932754f91461054f578063932997f1146105ac5780639d344c5d1461063b578063dfe68b5414610686575b600080fd5b34156100e957600080fd5b6100f16106e3565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101325780820151818401525b602081019050610116565b50505050905090810190601f16801561015f5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b341561017857600080fd5b6101aa600480803561ffff1690602001909190803560ff1690602001909190803560ff16906020019091905050610781565b005b34156101b757600080fd5b610207600480803590602001908201803590602001908080601f01602080910402602001604051908101604052809392919081815260200183838082843782019150505050505091905050610830565b005b341561021457600080fd5b61024c600480803573ffffffffffffffffffffffffffffffffffffffff1690602001909190803560ff169060200190919050506108a1565b604051808215151515815260200191505060405180910390f35b341561027157600080fd5b6102c1600480803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509190505061096f565b005b34156102ce57600080fd5b6102d66109e0565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156103175780820151818401525b6020810190506102fb565b50505050905090810190601f1680156103445780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b341561035d57600080fd5b610395600480803573ffffffffffffffffffffffffffffffffffffffff1690602001909190803560ff16906020019091905050610a9d565b005b34156103a257600080fd5b6103aa610bb2565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156103eb5780820151818401525b6020810190506103cf565b50505050905090810190601f1680156104185780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b341561043157600080fd5b610469600480803573ffffffffffffffffffffffffffffffffffffffff1690602001909190803560ff16906020019091905050610c6f565b005b341561047657600080fd5b61047e610d83565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156104bf5780820151818401525b6020810190506104a3565b50505050905090810190601f1680156104ec5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b341561050557600080fd5b61050d610e40565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b341561055a57600080fd5b6105aa600480803590602001908201803590602001908080601f01602080910402602001604051908101604052809392919081815260200183838082843782019150505050505091905050610e65565b005b34156105b757600080fd5b6105bf610ed6565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156106005780820151818401525b6020810190506105e4565b50505050905090810190601f16801561062d5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b341561064657600080fd5b61064e610f93565b604051808461ffff1661ffff1681526020018360ff1660ff1681526020018260ff1660ff168152602001935050505060405180910390f35b341561069157600080fd5b6106e1600480803590602001908201803590602001908080601f01602080910402602001604051908101604052809392919081815260200183838082843782019150505050505091905050610fe9565b005b60018054600181600116156101000203166002900480601f0160208091040260200160405190810160405280929190818152602001828054600181600116156101000203166002900480156107795780601f1061074e57610100808354040283529160200191610779565b820191906000526020600020905b81548152906001019060200180831161075c57829003601f168201915b505050505081565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141561082a5782600660006101000a81548161ffff021916908361ffff16021790555081600660026101000a81548160ff021916908360ff16021790555080600660036101000a81548160ff021916908360ff1602179055505b5b505050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141561089d57806004908051906020019061089b92919061106e565b505b5b50565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168473ffffffffffffffffffffffffffffffffffffffff1614156109025760019150610968565b600760008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16905060008360ff1660019060020a02821660ff16141591505b5092915050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614156109dc5780600290805190602001906109da92919061106e565b505b5b50565b6109e86110ee565b6109f2600161105a565b15610a995760038054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610a8d5780601f10610a6257610100808354040283529160200191610a8d565b820191906000526020600020905b815481529060010190602001808311610a7057829003601f168201915b50505050509050610a9a565b5b90565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415610bac57600760008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff1690508160ff1660019060020a02198116905080600760008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff021916908360ff1602179055505b5b505050565b610bba6110ee565b610bc4600261105a565b15610c6b5760048054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610c5f5780601f10610c3457610100808354040283529160200191610c5f565b820191906000526020600020905b815481529060010190602001808311610c4257829003601f168201915b50505050509050610c6c565b5b90565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415610d7d57600760008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff1690508160ff1660019060020a028117905080600760008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff021916908360ff1602179055505b5b505050565b610d8b6110ee565b610d95600361105a565b15610e3c5760058054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610e305780601f10610e0557610100808354040283529160200191610e30565b820191906000526020600020905b815481529060010190602001808311610e1357829003601f168201915b50505050509050610e3d565b5b90565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415610ed2578060039080519060200190610ed092919061106e565b505b5b50565b610ede6110ee565b610ee8600061105a565b15610f8f5760028054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610f835780601f10610f5857610100808354040283529160200191610f83565b820191906000526020600020905b815481529060010190602001808311610f6657829003601f168201915b50505050509050610f90565b5b90565b6000806000610fa2600461105a565b15610fe357600660009054906101000a900461ffff16600660029054906101000a900460ff16600660039054906101000a900460ff16925092509250610fe4565b5b909192565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141561105657806005908051906020019061105492919061106e565b505b5b50565b600061106633836108a1565b90505b919050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106110af57805160ff19168380011785556110dd565b828001600101855582156110dd579182015b828111156110dc5782518255916020019190600101906110c1565b5b5090506110ea9190611102565b5090565b602060405190810160405280600081525090565b61112491905b80821115611120576000816000905550600101611108565b5090565b905600a165627a7a7230582015975d6824d8a722c7cde9691906ed68f7e12c5c861aafb34e03e11f11f702de0029"

'mainwallet = "0xf34b6c32917f957068df1b2205b5061924fe13dd"
mainwallet = "0x451480c97eba1b6ed9d167964b172be7cae4be08"
'mainpassword = "12345"
mainpassword = "VdomAzure"

function save_account(a)
  set b = new buffer
  b.write(a)
  b.seek(0)
  tempresources.write("account", b)
end function

function save_contract(c)
  set b = new buffer
  b.write(c)
  b.seek(0)
  tempresources.write("contract", b)
end function

function save_transaction(t)
  set b = new buffer
  b.write(t)
  b.seek(0)
  tempresources.write("transaction", b)
end function

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

function read_transaction
  try
    read_transaction = tempresources.open("transaction").read()
    logger "Transaction " & read_transaction
  catch
    read_transaction = ""
  end try
end function

account_id = read_account()
contract_id = read_contract()
transaction_id = read_transaction()

set myclient = new web3client
myclient.host = client_host
myclient.port = client_port
if account_id <> "" then
  myclient.account = account_id
  myclient.unlock_account(client_password)
end if

function read_profile(client)
  d = new dictionary
  d("firstName") = client.contract_call(abi, contract_id, "getFirstName")
  d("lastName") = client.contract_call(abi, contract_id, "getLastName")
  d("email") = client.contract_call(abi, contract_id, "getEmail")
  d("phone") = client.contract_call(abi, contract_id, "getPhone")
  birthday = client.contract_call(abi, contract_id, "getBirthday")
  d("birthday") = birthday(2) & "." & birthday(1) & "." & birthday(0)
  read_profile = d
end function

args = xml_dialog.get_answer

if "step" in args then
  if args( "step" )<>"" then
    operation_step = args( "step" )
  end if
else
  operation_step =""
end if

if operation_step = "" then
  if account_id = "" then
    operation_step = "NewAccount"
  end if
  if (account_id <> "" and contract_id = "") then
    operation_step = "NewProfile"
  end if
  if (account_id <> "" and contract_id <> "") then
    operation_step = "ExistingProfile"
  end if
end if

set MyForms = New XMLDialogBuilder

MyForms.addScreen("NewAccount")
MyForms.Screen("NewAccount").width  = 600
MyForms.Screen("NewAccount").Height = 400
MyForms.Screen("NewAccount").Title = "My Account"
MyForms.Screen("NewAccount").addComponent("caption", "text")
MyForms.Screen("NewAccount").Component("caption").value("Press the button below to create your Ethereum account")
MyForms.Screen("NewAccount").addComponent("btns", "btngroup")
MyForms.Screen("NewAccount").Component("btns").addBtn("Create", "Create")

MyForms.addScreen("NewProfile")
MyForms.Screen("NewProfile").width  = 600
MyForms.Screen("NewProfile").Height = 400
MyForms.Screen("NewProfile").Title = "My Profile"
MyForms.Screen("NewProfile").addComponent("account", "text")
MyForms.Screen("NewProfile").Component("account").value("Your account is " & account_id)
MyForms.Screen("NewProfile").addComponent("caption", "text")
MyForms.Screen("NewProfile").Component("caption").value("Fill the following fields to create your profile")
MyForms.Screen("NewProfile").addComponent("firstname", "TextBox")
MyForms.Screen("NewProfile").Component("firstname").label("First name :")
MyForms.Screen("NewProfile").addComponent("lastname", "TextBox")
MyForms.Screen("NewProfile").Component("lastname").label("Last name :")
MyForms.Screen("NewProfile").addComponent("email", "TextBox")
MyForms.Screen("NewProfile").Component("email").label("E-mail :")
MyForms.Screen("NewProfile").addComponent("phone", "TextBox")
MyForms.Screen("NewProfile").Component("phone").label("Phone number :")
MyForms.Screen("NewProfile").addComponent("birthday", "TextBox")
MyForms.Screen("NewProfile").Component("birthday").label("Birthday :")
MyForms.Screen("NewProfile").addComponent("btns", "btngroup")
MyForms.Screen("NewProfile").Component("btns").addBtn("OK", "CreateProfile")

'####################################################################

function create_account
  acc = myclient.create_account(client_password)
  call save_account(acc)
  set wallet = new web3client
  wallet.host = client_host
  wallet.port = client_port
  wallet.account = mainwallet
  wallet.unlock_account(mainpassword)
  tid = wallet.send_ether(acc, 2)
  call save_transaction(tid)
  create_account = acc
end function

function create_profile
  param = Array
  Redim param(7)
  user = appinmail.currentuser()
  param(0) = user("guid")
  param(1) = args("firstname")
  param(2) = args("lastname")
  param(3) = args("email")
  param(4) = args("phone")
  param(5) = cint(split(args("birthday"), ".")(2))
  param(6) = cint(split(args("birthday"), ".")(1))
  param(7) = cint(split(args("birthday"), ".")(0))
  tid = myclient.deploy_contract(abi, code, param)
  call save_transaction(tid)
end function

'####################################################################

if instr(operation_step,">")<>0 then
  mainStep = split(operation_step,">")(0)
  subStep = split(operation_step,">")(1)
else
  mainStep = operation_step
  subStep = ""
end if

Select case mainStep

  case "NewAccount"
    MyForms.ShowScreen("NewAccount")

  case "Create"
    acc = create_account()
    MyForms.addScreen("WaitInitialTransaction")
    MyForms.Screen("WaitInitialTransaction").width  = 600
    MyForms.Screen("WaitInitialTransaction").Height = 400
    MyForms.Screen("WaitInitialTransaction").Title = "My Account"
    MyForms.Screen("WaitInitialTransaction").addComponent("account", "text")
    MyForms.Screen("WaitInitialTransaction").Component("account").value("Your account is " & acc)
    MyForms.Screen("WaitInitialTransaction").addComponent("caption", "text")
    MyForms.Screen("WaitInitialTransaction").Component("caption").value("Transaction is being processed...")
    MyForms.Screen("WaitInitialTransaction").addComponent("btns", "btngroup")
    MyForms.Screen("WaitInitialTransaction").Component("btns").addBtn("Update", "WaitInitialTransaction")
    MyForms.ShowScreen("WaitInitialTransaction")

  case "WaitInitialTransaction"
    MyForms.addScreen("WaitInitialTransaction")
    MyForms.Screen("WaitInitialTransaction").width  = 600
    MyForms.Screen("WaitInitialTransaction").Height = 400
    MyForms.Screen("WaitInitialTransaction").Title = "My Account"
    MyForms.Screen("WaitInitialTransaction").addComponent("account", "text")
    MyForms.Screen("WaitInitialTransaction").Component("account").value("Your account is " & account_id)
    set wallet = new web3client
    wallet.host = client_host
    wallet.port = client_port
    wallet.account = mainwallet
    wallet.unlock_account(mainpassword)
    rcpt = wallet.get_transaction_receipt(transaction_id)
    logger rcpt
    if isempty(rcpt) then
      MyForms.Screen("WaitInitialTransaction").addComponent("caption", "text")
      MyForms.Screen("WaitInitialTransaction").Component("caption").value("Transaction is being processed...")
      MyForms.Screen("WaitInitialTransaction").addComponent("btns", "btngroup")
      MyForms.Screen("WaitInitialTransaction").Component("btns").addBtn("Update", "WaitInitialTransaction")
      MyForms.ShowScreen("WaitInitialTransaction")
    else
      MyForms.Screen("WaitInitialTransaction").addComponent("caption", "text")
      MyForms.Screen("WaitInitialTransaction").Component("caption").value("Transaction complete")
      MyForms.Screen("WaitInitialTransaction").addComponent("btns", "btngroup")
      MyForms.Screen("WaitInitialTransaction").Component("btns").addBtn("Next", "NewProfile")
      MyForms.ShowScreen("WaitInitialTransaction")
    end if

  case "NewProfile"
    MyForms.ShowScreen("NewProfile")

  case "CreateProfile"
    call create_profile
    MyForms.addScreen("WaitProfile")
    MyForms.Screen("WaitProfile").width  = 600
    MyForms.Screen("WaitProfile").Height = 400
    MyForms.Screen("WaitProfile").Title = "My Profile"
    MyForms.Screen("WaitProfile").addComponent("caption", "text")
    MyForms.Screen("WaitProfile").Component("caption").value("Transaction is being processed...")
    MyForms.Screen("WaitProfile").addComponent("btns", "btngroup")
    MyForms.Screen("WaitProfile").Component("btns").addBtn("Update", "WaitProfile")
    MyForms.ShowScreen("WaitProfile")

  case "WaitProfile"
    MyForms.addScreen("WaitProfile")
    MyForms.Screen("WaitProfile").width  = 600
    MyForms.Screen("WaitProfile").Height = 400
    MyForms.Screen("WaitProfile").Title = "My Profile"
    addr = myclient.get_contract_address(transaction_id)
    if isempty(addr) then
      MyForms.Screen("WaitProfile").addComponent("caption", "text")
      MyForms.Screen("WaitProfile").Component("caption").value("Transaction is being processed...")
      MyForms.Screen("WaitProfile").addComponent("btns", "btngroup")
      MyForms.Screen("WaitProfile").Component("btns").addBtn("Update", "WaitProfile")
      MyForms.ShowScreen("WaitProfile")
    else
      call save_contract(addr)
      MyForms.Screen("WaitProfile").addComponent("caption", "text")
      MyForms.Screen("WaitProfile").Component("caption").value("Transaction complete")
      MyForms.Screen("WaitProfile").addComponent("btns", "btngroup")
      MyForms.Screen("WaitProfile").Component("btns").addBtn("OK", "End")
      MyForms.ShowScreen("WaitProfile")
    end if

  case "ExistingProfile"
    p = read_profile(myclient)
    MyForms.addScreen("ExistingProfile")
    MyForms.Screen("ExistingProfile").width  = 600
    MyForms.Screen("ExistingProfile").Height = 400
    MyForms.Screen("ExistingProfile").Title = "My Profile"
    MyForms.Screen("ExistingProfile").addComponent("account", "text")
    MyForms.Screen("ExistingProfile").Component("account").value("Your account is " & account_id)
    MyForms.Screen("ExistingProfile").addComponent("firstname", "TextBox")
    MyForms.Screen("ExistingProfile").Component("firstname").label("First name :")
    MyForms.Screen("ExistingProfile").Component("firstname").defaultValue(p("firstName"))
    MyForms.Screen("ExistingProfile").addComponent("lastname", "TextBox")
    MyForms.Screen("ExistingProfile").Component("lastname").label("Last name :")
    MyForms.Screen("ExistingProfile").Component("lastname").defaultValue(p("lastName"))
    MyForms.Screen("ExistingProfile").addComponent("email", "TextBox")
    MyForms.Screen("ExistingProfile").Component("email").label("E-mail :")
    MyForms.Screen("ExistingProfile").Component("email").defaultValue(p("email"))
    MyForms.Screen("ExistingProfile").addComponent("phone", "TextBox")
    MyForms.Screen("ExistingProfile").Component("phone").label("Phone number :")
    MyForms.Screen("ExistingProfile").Component("phone").defaultValue(p("phone"))
    MyForms.Screen("ExistingProfile").addComponent("birthday", "TextBox")
    MyForms.Screen("ExistingProfile").Component("birthday").label("Birthday :")
    MyForms.Screen("ExistingProfile").Component("birthday").defaultValue(p("birthday"))
    MyForms.Screen("ExistingProfile").addComponent("btns", "btngroup")
    MyForms.Screen("ExistingProfile").Component("btns").addBtn("Update", "UpdateProfile")
    MyForms.Screen("ExistingProfile").Component("btns").addBtn("Close", "Close")
    MyForms.ShowScreen("ExistingProfile")

  case "UpdateProfile"
    p = read_profile(myclient)
    upd = 0

    if p("firstName") <> args("firstname") then
      tid = myclient.contract_call(abi, contract_id, "setFirstName", args("firstname"), 0, true)
      upd = 1
      logger "First Name update transaction: " & tid
    end if

    if p("lastName") <> args("lastname") then
      tid = myclient.contract_call(abi, contract_id, "setLastName", args("lastname"), 0, true)
      upd = 1
      logger "Last Name update transaction: " & tid
    end if

    if p("email") <> args("email") then
      tid = myclient.contract_call(abi, contract_id, "setEmail", args("email"), 0, true)
      upd = 1
      logger "Email update transaction: " & tid
    end if

    if p("phone") <> args("phone") then
      tid = myclient.contract_call(abi, contract_id, "setPhone", args("phone"), 0, true)
      upd = 1
      logger "Phone update transaction: " & tid
    end if

    if p("birthday") <> args("birthday") then
      param = Array
      Redim param(2)
      param(0) = cint(split(args("birthday"), ".")(2))
      param(1) = cint(split(args("birthday"), ".")(1))
      param(2) = cint(split(args("birthday"), ".")(0))
      tid = myclient.contract_call(abi, contract_id, "setBirthday", param, 0, true)
      upd = 1
      logger "Birthday update transaction: " & tid
    end if

    MyForms.addScreen("UpdateDone")
    MyForms.Screen("UpdateDone").width  = 600
    MyForms.Screen("UpdateDone").Height = 400
    MyForms.Screen("UpdateDone").Title = "My Profile"
    MyForms.Screen("UpdateDone").addComponent("caption", "text")
    if upd <> 0 then
      MyForms.Screen("UpdateDone").Component("caption").value("Your profile was updated")
    else
      MyForms.Screen("UpdateDone").Component("caption").value("Nothing changed")
    end if
    MyForms.Screen("UpdateDone").addComponent("btns", "btngroup")
    MyForms.Screen("UpdateDone").Component("btns").addBtn("Close", "Close")
    MyForms.ShowScreen("UpdateDone")

end select