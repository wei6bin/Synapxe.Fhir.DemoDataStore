// -------------------------------------------------------------------------------------------------
// Copyright (c) Integrated Health Information Systems Pte Ltd. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace Synapxe.FhirNexus.Relational.Data;

public class FhirEntityDbContext : DbContext
{
    public FhirEntityDbContext(DbContextOptions<FhirEntityDbContext> options)
        : base(options)
    {
    }

    public DbSet<PatientHealthRecordEntity> PatientHealthRecord => Set<PatientHealthRecordEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseFhirConventions(this);
    }
}
