import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { ListUsers } from "./components/ListUsers";
import { ListMenuUsers } from "./components/ListMenuUsers";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
    path: '/list-users',
    element: <ListUsers />
    },
    {
    path: '/show_menus_users',
    element: <ListMenuUsers />
    }
];

export default AppRoutes;
