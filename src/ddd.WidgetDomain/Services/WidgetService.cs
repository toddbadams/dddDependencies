using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ddd.AddressDomain.Services;
using ddd.Core.Entities;
using ddd.Core.Entities.WidgetDomain;
using ddd.Core.Logging;
using ddd.Core.Persistence;
using ddd.Core.Providers;
using ddd.Core.Queries;
using ddd.WidgetDomain.Models;

namespace ddd.WidgetDomain.Services
{
    public class WidgetService
    {
        private readonly IRepository<Widget> _widgetRepository;
        private readonly IAddressService _addressService;
        private readonly ILog _log;
        private readonly ISerializationProvider _serializationProvider;

        public WidgetService(IRepository<Widget> widgetRepository,
            IAddressService addressService,
            ILog log,
            ISerializationProvider serializationProvider)
        {
            _widgetRepository = widgetRepository;
            _addressService = addressService;
            _log = log;
            _serializationProvider = serializationProvider;
        }

        /// <summary>
        /// Fetch a paged set of Widgets within a given distance of lat/long
        /// </summary>
        /// <param name="request">A request model</param>
        /// <returns>a pages set of Widget summaries</returns>
        public async Task<IEnumerable<WidgetSummary>> FetchSummaryWithinDistance(WidgetSummary.Request request)
        {
            var m = string.Format("VenuService.FetchSummaryWithinDistance(request={0})",
                _serializationProvider.Serialize(request));
            try
            {
                _log.Debug(m);
                var widgets = _widgetRepository.AsQuery()
                    .Paged(request.Start, request.Limit);
                var results = await CreateWidgetSummaries(widgets.Queryable, request.Distance);
                return results;
            }
            catch (Exception ex)
            {
                _log.Error(m, ex);
                throw;
            }
        }

        private async Task<IEnumerable<WidgetSummary>> CreateWidgetSummaries(IEnumerable<Widget> widgets, decimal distance)
        {
            var results = new List<WidgetSummary>();
            await Task.WhenAll(widgets.Select(widget => CreateWidgetSummary(widget, distance, results)));
            return results;
        }

        private async Task CreateWidgetSummary(Widget widget, decimal distance, ICollection<WidgetSummary> results)
        {
            var address = await _addressService.Get(widget.Id, ParentEntityType.Widget);
            results.Add(WidgetSummary.Create(widget, address, distance));
        }
    }
}
