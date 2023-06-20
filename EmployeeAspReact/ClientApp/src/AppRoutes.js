import { ViewAll } from "./components/ViewAllEmploees";
import { Home } from "./components/Home";
import { Add } from "./components/AddEmployee";
import { Delete } from './components/DeleteEmployee';
import { Search } from './components/Search';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/ViewAll',
      element: <ViewAll />
  },
  {
    path: '/Add',
    element: <Add />
   },
   {
    path: '/Delete',
    element: <Delete />
   },
   {
    path: 'Search',
    element: <Search />
   }
];

export default AppRoutes;
