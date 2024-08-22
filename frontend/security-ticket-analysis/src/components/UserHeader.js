import React from 'react';

const UserHeader = ({ user }) => (
  <div className="user-header">
    <div className="user-info">
      <h2>{user.name}</h2>
      <p>{user.email}</p>
    </div>
    <span className={`status-badge ${user.status.toLowerCase()}`}>
      {user.status}
    </span>
  </div>
);

export default UserHeader;
