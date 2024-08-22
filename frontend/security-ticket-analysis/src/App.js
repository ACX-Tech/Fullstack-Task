import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import UserPage from './pages/UserPage';
import { getUsersWithConversations } from './services/api';

function App() {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchUsers = async () => {
      const data = await getUsersWithConversations();
      setUsers(data);
    };

    fetchUsers();
  }, []);

  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/user/:userId" element={<UserPage users={users} />} />
      </Routes>
    </Router>
  );
}

export default App;
