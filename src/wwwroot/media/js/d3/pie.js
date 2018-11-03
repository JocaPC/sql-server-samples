/*
* D3 PieChart Control.
* Encapsulated example from: https://bl.ocks.org/mbostock/3887235
* Licence: GNU General Public License, version 3
* Authors: Mike Bostock, Jovan Popovic
**************************************************************************/

var Pie = function(target, options) {

    options = options || {};
    this.options = options;
    var _fnGetDate = options.date || function(d) { return d.Date; };
    var _fnGetValue = options.value || function(d) { return d[0].Value; };

var svg = d3.select(target),
    width = options.width||0+svg.attr("width"),
    height = options.height||0+svg.attr("height"),
    radius = Math.min(width, height) / 2,
    g = svg.append("g").attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

var color = d3.scaleOrdinal(options.colors || ["#98abc5", "#8a89a6", "#7b6888", "#6b486b", "#a05d56", "#d0743c", "#ff8c00"]);

var pie = d3.pie()
    .sort(null)
    .value(function(d) { return d.value; });

var path = d3.arc()
    .outerRadius(radius - 10)
    .innerRadius(options.innerRadius || 0);

var label = d3.arc()
    .outerRadius(radius - 40)
    .innerRadius(radius - 40);

this.Data = function(data) {
  var arc = g.selectAll(".arc")
    .data(pie(data))
    .enter().append("g")
      .attr("class", "arc");

  arc.append("path")
      .attr("d", path)
      .attr("fill", function(d) { return color(d.data.key); });

  arc.append("text")
      .attr("transform", function(d) { return "translate(" + label.centroid(d) + ")"; })
      .attr("dy", "0.35em")
      .text(function(d) { return d.data.key; });
}

};