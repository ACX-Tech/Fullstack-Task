import axios from 'axios';

const API_URL = 'https://localhost:7006/api';

export const getUsersWithConversations = async () => {
  try {
    const response = await axios.get(`${API_URL}/tickets`);
    return response.data;
  } catch (error) {
    console.error('Error fetching users:', error);
    throw error;
  }
};
