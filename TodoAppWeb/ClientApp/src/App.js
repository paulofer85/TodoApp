import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Todo } from './components/Todo';
import { TodoSearch } from './components/TodoSearch';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/todo' component={Todo} />
        <Route path='/todoSearch' component={TodoSearch} />
      </Layout>
    );
  }
}
