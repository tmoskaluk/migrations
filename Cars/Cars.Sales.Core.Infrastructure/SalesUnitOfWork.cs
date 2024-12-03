using Cars.Core.Base.UnitOfWork;
using Cars.Sales.Core.Domain;

namespace Cars.Sales.Core.Infrastructure;

public class SalesUnitOfWork(SalesDbContext context) : EntityFrameworkUnitOfWork<SalesDbContext>(context), ISalesUnitOfWork;