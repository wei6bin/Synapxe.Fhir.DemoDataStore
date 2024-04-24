# FHIRNexus Custom Resource on 3 data store type
## Steps for DEMO Project

- navigate the to folder `Synapxe.Fhir.DemoDataStore` and open visual studio code `code .`

## **Model project**
- create the model project

```bash
dotnet new classlib --name Synapxe.FhirNexus.Model
```

- add the Custom resource StructureDefinition file and PatientHealthRecord class to the project (refer to `/material/0.model_project`)
- add the reference, FhirEngine package, and the Fhir.CodeGeneration package which to generate the custom resource class 

```xml
  <ItemGroup>
    <PackageReference Include="Ihis.FhirEngine.R5" Version="4.0.0" />
    <PackageReference Include="Synapxe.Fhir.CodeGeneration" Version="1.0.0-*" />
  </ItemGroup>
```

- build the project, the FHIR model class generated

## **Document API project**
- Go to document API project `Synapxe.FhirNexus.Document`
  1. `fhirengine.json` add below under system setting
    * under `SystemPlugins`
    
      "CustomResources": ["Synapxe.FhirNexus.Model.PatientHealthRecord"],
 
    * `AcceptTypes`, to add `"PatientHealthRecord"`

  2. copy over the structure definition file `PatientHealthRecord.StructureDefinition.json`, it will be used by API for FHIR profile validation

  3. add below to line 66 to file `capability-statement.json`
```json
        {
          "type": "PatientHealthRecord",
          "interaction": [
            {
              "code": "read"
            },
            {
              "code": "vread"
            },
            {
              "code": "update"
            },
            {
              "code": "patch"
            },
            {
              "code": "create"
            },
            {
              "code": "delete"
            },
            {
              "code": "search-type"
            }
          ],
          "versioning": "versioned"
        }
```

  4. build and run the project, to view the swagger file
    * interactions 
    * fhir data model defined
https://localhost:7190/swagger/index.html

  5. explore the http file with the different API request

## **Relational API project**
  1. copy over the DB context and model to the project (refer to `/material/2.relational_project`).
  2. build and run the project
  3. explore the http file with the different API request

## **Custom data store API project**

  1. copy over the DB context and model to the project (refer to `/material/3.custom_project`), `PatientHealthRecordModel.cs` and `PatientHealthRecordDataMapper.cs`, explore the data field and data mapper logic.
  2. build and run the project
  3. explore the http file with the different API request