using Hl7.Fhir.Model;
using Ihis.FhirEngine.Core.Handlers.Data;
using Synapxe.FhirNexus.Model;

namespace Synapxe.FhirNexus.Custom.Data
{
    public class PatientHealthRecordDataMapper : IFhirDataMapper<PatientHealthRecordModel, PatientHealthRecord>
    {
        public PatientHealthRecord Map(PatientHealthRecordModel model)
        {
            var record = new PatientHealthRecord
            {
                Id = model.Id.ToString("N").ToUpper(),
                Meta = new Meta
                {
                    VersionId = model.VersionId.ToString(),
                    LastUpdated = model.LastUpdated,
                },
                Status = model.Status,
            };

            if (model.LifestyleRecord != null)
            {
                record.Lifestyle = new PatientHealthRecord.LifestyleComponent()
                {
                    SmokingStatus = model.LifestyleRecord.Smoking,
                    AlcoholConsumption = model.LifestyleRecord.AlcoholConsumption,
                    ExerciseFrequency = model.LifestyleRecord.ExerciseFrequency,
                };
            }

            if (model.FamilyHistoryRecords != null)
            {
                record.FamilyHistory = new List<PatientHealthRecord.FamilyHistoryComponent>();
                foreach (var item in model.FamilyHistoryRecords)
                {
                    record.FamilyHistory.Add(new PatientHealthRecord.FamilyHistoryComponent()
                    {
                        Condition = item.Condition,
                        Relationship = item.Relationship
                    });
                }
            }

            return record;
        }

        public PatientHealthRecordModel ReverseMap(PatientHealthRecord resource)
        {
            var model = new PatientHealthRecordModel()
            {
                Id = Guid.Parse(resource.Id),
                VersionId = int.TryParse(resource.VersionId, out var vid) ? vid : 0,
                LastUpdated = resource.Meta?.LastUpdated,
                Status = resource.Status,
            };

            if (resource.Lifestyle != null)
            {
                model.LifestyleRecord = new LifestyleEntity()
                {
                    Smoking = resource.Lifestyle.SmokingStatus ?? string.Empty,
                    AlcoholConsumption = resource.Lifestyle.AlcoholConsumption ?? string.Empty,
                    ExerciseFrequency = resource.Lifestyle.ExerciseFrequency ?? string.Empty
                };
            }

            if (resource.FamilyHistory != null)
            {
                model.FamilyHistoryRecords = new List<FamilyHistoryEntity>();
                foreach (var familyHistoryRecord in resource.FamilyHistory)
                {
                    model.FamilyHistoryRecords.Add(new FamilyHistoryEntity()
                    {
                        Condition = familyHistoryRecord.Condition,
                        Relationship = familyHistoryRecord.Relationship,
                    });
                }
            }

            return model;
        }
    }
}
