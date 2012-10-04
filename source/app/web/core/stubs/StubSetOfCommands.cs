﻿using System.Collections;
using System.Collections.Generic;
using System.Web;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new RequestCommand(x => true, new ViewAReport<IEnumerable<DepartmentItem>>(
                                                   secure<GetTheMainDepartments, IEnumerable<DepartmentItem>>(
                                                     new GetTheMainDepartments())));

      yield return new RequestCommand(x => true, new ViewAReport<IEnumerable<DepartmentItem>>(
                                                   new GetTheMainDepartments()));

      yield return new RequestCommand(x => true, new ViewAReport<IEnumerable<DepartmentItem>>(
                                                   new GetTheDepartmentsInADepartment()));
    }

    IFetchAReport<Report> secure<Query,Report>(Query query) where Query : IFetchAReport<Report>
    {
      return new UserConstrainedQuery<Report>(null, () => HttpContext.Current.User,
                                              query);
    }

    public class GetTheDepartmentsInADepartment : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IEncapsulateRequestDetails request)
      {
        return new StubStoreCatalog().get_departments_using(request.map<ViewSubDepartmentRequest>());
      }
    }

    public class GetTheProductsInADepartment : IFetchAReport<IEnumerable<ProductItem>>
    {
      public IEnumerable<ProductItem> fetch_using(IEncapsulateRequestDetails request)
      {
        return new StubStoreCatalog().get_the_products_using(request.map<ViewProductsInADepartmentRequest>());
      }
    }

    public class GetTheMainDepartments : IFetchAReport<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_using(IEncapsulateRequestDetails request)
      {
        return new StubStoreCatalog().get_the_main_departments();
      }
    }
  }
}