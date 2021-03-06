﻿using Matriculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matriculas.Queries.Core.Repositories
{
    public interface IAniosAcademicosRepository : IRepository<AnioAcademico>
    {
        AnioAcademico GetAnioAcademico(int anio);

        IEnumerable<Cronograma> GetCronogramas(int id);

        AnioAcademico GetByName(int name);

        bool HasNombreUnique(AnioAcademico entity);
    }
}
