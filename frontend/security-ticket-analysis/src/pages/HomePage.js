import React, { useState, useEffect } from 'react';
import { getUsersWithConversations } from '../services/api';
import { Link } from 'react-router-dom';

const HomePage = () => {
  const [users, setUsers] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [sortAsc, setSortAsc] = useState(true);

  useEffect(() => {
    const fetchUsers = async () => {
      const data = await getUsersWithConversations();
      setUsers(data);
    };
    fetchUsers();
  }, []);

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
  };

  const handleSort = () => {
    setSortAsc(!sortAsc);
    setUsers(users.slice().sort((a, b) => sortAsc ? a.name.localeCompare(b.name) : b.name.localeCompare(a.name)));
  };

  const filteredUsers = users.filter(user =>
    user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
    user.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div>
      <h1>User List</h1>
      <input
        type="text"
        placeholder="Search by name or email"
        value={searchTerm}
        onChange={handleSearch}
      />
      <button onClick={handleSort}>
        Sort by Name {sortAsc ? '▲' : '▼'}
      </button>
      <ul>
        {filteredUsers.map(user => (
          <li key={user.userId}>
            <Link to={`/user/${user.userId}`}>
              {user.name} (Tickets: {user.conversations.length})
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default HomePage;
