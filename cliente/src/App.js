import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import CustomerScreen from './screens/Customer';
import EmployeeScreen from './screens/Employee';

function App() {
  return (
    <Router>
      <div className="App">
        <Switch>
          <Route path="/employees" component={EmployeeScreen}/>
          <Route path="/customers" component={CustomerScreen}/>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
