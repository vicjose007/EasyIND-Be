using AutoMapper;
using EasyIND.Application.Common.Interfaces;
using EasyIND.Application.Mappings;
using EasyIND.Application.Services;
using EasyIND.Domain.Entities;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.Generic.Services;
using EasyIND.Infrastructure.Repositories;
using EasyIND.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyIND.Test
{
    public class BaseTestService 
    {
        protected readonly IAreaService areaService;
        protected readonly ICareerService careerService;
        protected readonly IProfessorService professorService;
        protected readonly IQualificationService qualificationService;
        protected readonly IRegistroService registroService;
        protected readonly ISubjectService subjectService;
        protected readonly IUserService userService;
        protected readonly IServiceProvider serviceProvider;
        protected readonly IUnitOfWork<IEasyINDDbContext> uow;

        public BaseTestService()
        {
            var mapper = new MapperConfiguration(x => x.AddProfile<NoteProfile>()).CreateMapper();
            var optionsBuilder = new DbContextOptionsBuilder<EasyINDDbContext>();
            optionsBuilder.UseInMemoryDatabase("EasyINDDB");
            var context = new EasyINDDbContext(optionsBuilder.Options);

            var areaRepository = new AreaRepository(context);
            var subjectRepository = new SubjectRepository(context);
            var careerRepository = new CareerRepository(context);
            var qualificationRepository = new QualificationRepository(context);
            var registroRepository = new RegistroRepository(context);
            var professorRepository = new ProfessorRepository(context);
            var userRepository = new UserRepository(context);

            var areaServiceCollection = new ServiceCollection(); areaServiceCollection.AddScoped(typeof(AreaService)); 
            serviceProvider = areaServiceCollection.BuildServiceProvider();

            var careerServiceCollection = new ServiceCollection(); careerServiceCollection.AddScoped(typeof(CareerService));
            serviceProvider = careerServiceCollection.BuildServiceProvider();

            var subjectServiceCollection = new ServiceCollection(); subjectServiceCollection.AddScoped(typeof(SubjectService));
            serviceProvider = subjectServiceCollection.BuildServiceProvider();

            var qualificationServiceCollection = new ServiceCollection(); qualificationServiceCollection.AddScoped(typeof(QualificationService));
            serviceProvider = qualificationServiceCollection.BuildServiceProvider();

            var registroServiceCollection = new ServiceCollection(); registroServiceCollection.AddScoped(typeof(RegistroService));
            serviceProvider = registroServiceCollection.BuildServiceProvider();

            var professorServiceCollection = new ServiceCollection(); professorServiceCollection.AddScoped(typeof(ProfessorService));
            serviceProvider = professorServiceCollection.BuildServiceProvider();

            var userServiceCollection = new ServiceCollection(); userServiceCollection.AddScoped(typeof(UserService));
            serviceProvider = userServiceCollection.BuildServiceProvider();

            uow = new EasyINDUnitOfWork(serviceProvider, context);

            areaService = new AreaService(mapper, uow , areaRepository);
            subjectService = new SubjectService(mapper, uow, subjectRepository);
            careerService = new CareerService(mapper, uow, careerRepository);
            qualificationService = new QualificationService(mapper, uow, qualificationRepository);
            professorService = new ProfessorService(mapper, uow, professorRepository);
            registroService = new RegistroService(mapper, uow, registroRepository);
            userService = new UserService(mapper, uow, userRepository);
        }
    }
}
