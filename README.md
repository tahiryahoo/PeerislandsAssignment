# PeerislandsAssignment
Here we are trying to create xml parser. Which will create and read xml name of model name, like if we would have model name "EmployeeModel" then file name will be created as "EmployeeModel.xml". The location of xml file will be the "MyDocuments" folder in repective machine.

![image](https://user-images.githubusercontent.com/100024399/156155352-aaa62a45-7230-4c62-a518-d436135d8c08.png)

## Components
* XmlParserLibrary (Deployeed on nuget.org)
* PeerislandXmlParsor Web API (Consumer of XmlParserLibrary)

## Execution Steps
* Resolve dependacy of XmlParserLibrary from nuget
* Build PeerislandXmlParsor Web API
* Run PeerislandXmlParsor Web API
* Browse Url like https://localhost:44337/swagger
* Get view like above
* Employee routes has coverted problem statment 1
* Designation routes has coverted probelm statment 2
* In XmlParserLibrary We have "IEmployeeModel" interface for further extension of employee model.