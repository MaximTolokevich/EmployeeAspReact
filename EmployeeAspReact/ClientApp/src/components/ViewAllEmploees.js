import React, { Component } from 'react';

export class ViewAll extends Component {
  static displayName = ViewAll.name;

  constructor(props) {
    super(props);
    this.state = { employee: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderTable(employee) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Age</th>
            <th>Car</th>
          </tr>
        </thead>
        <tbody>
          {employee.map(forecast =>
              <tr key={forecast.id}>
              <td>{forecast.id}</td>
              <td>{forecast.name}</td>
              <td>{forecast.age}</td>
              <td>{forecast.car}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : ViewAll.renderTable(this.state.employee);

    return (
      <div>
        <h1 id="tableLabel">Employee</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('https://localhost:5001/api/Home');
    const data = await response.json();
    this.setState({ employee: data, loading: false });
  }
}
