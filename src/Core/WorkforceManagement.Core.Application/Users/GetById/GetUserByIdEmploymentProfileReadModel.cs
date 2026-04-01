using System;

namespace WorkforceManagement.Core.Application.Users.GetById
{
    public sealed class GetUserByIdEmploymentProfileReadModel
    {
        public GetUserByIdEmploymentProfileReadModel(
            int id,
            string positionTitle,
            DateTime hireDate,
            DateTime? probationEndDate)
        {
            Id = id;
            PositionTitle = positionTitle;
            HireDate = hireDate;
            ProbationEndDate = probationEndDate;
        }

        public int Id { get; }
        public string PositionTitle { get; }
        public DateTime HireDate { get; }
        public DateTime? ProbationEndDate { get; }
    }
}
