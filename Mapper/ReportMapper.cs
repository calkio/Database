using Database.BLL.Entity;
using Database.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Mapper
{
    internal static class ReportMapper
    {
        public static Report ToBLL(this ReportDAL entity)
        {
            return new Report(
                    id: entity.Id,
                    phototrace: entity.Phototrace,
                    dateTime: entity.DateTime,
                    diagnosis: entity.Diagnosis,
                    height: entity.Height,
                    outsideDiameter: entity.OutsideDiameter,
                    innerDiameter: entity.InnerDiameter,
                    coilDiameter: entity.CoilDiameter,
                    perpendicularity: entity.Perpendicularity,
                    kit: entity.Kit,
                    springMarker: entity.SpringMarker,
                    cartType: entity.CartType,
                    idInstallationWorker: entity.IdInstallationWorker
                );
        }

        public static ReportDAL ToDAL(this Report model)
        {
            return new ReportDAL
            {
                Id = model.Id,
                Phototrace = model.Phototrace,
                DateTime = model.DateTime,
                Diagnosis = model.Diagnosis,
                Height = model.Height,
                OutsideDiameter = model.OutsideDiameter,
                InnerDiameter = model.InnerDiameter,
                CoilDiameter = model.CoilDiameter,
                Perpendicularity = model.Perpendicularity,
                Kit = model.Kit,
                SpringMarker = model.SpringMarker,
                CartType = model.CartType,
                IdInstallationWorker = model.IdInstallationWorker
            };
        }
    }
}
